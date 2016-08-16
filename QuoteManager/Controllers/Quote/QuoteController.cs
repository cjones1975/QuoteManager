using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuoteManager.Dal;
using QuoteManager.Helpers;
using QuoteManager.Models.Database.Quote;
using QuoteManager.Models.Database.Product;
using QuoteManager.Models.ViewModel.Quote;
using QuoteManager.Models.ViewModel.Product;
using QuoteManager.Models.ViewModel.Error;
using System.Web.Security;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Web.UI;

namespace QuoteManager.Controllers.Quote
{
    public class QuoteController : Controller
    {
        private readonly UnitOfWork unitOfWork = new UnitOfWork();

        private object QueryStringValue(string param)
        {
            object value = null;
            string sessionQueryString = (String)Session["QuotesQueryString"];
            string qs = Security.DecryptString(sessionQueryString.Replace(" ", "+"), true);
            char[] delimiterChars = { '=', '&' };
            string[] urlParam = qs.Split(delimiterChars);
            for (int i = 0; i < urlParam.Length; i += 2)
            {
                if (String.Compare(Convert.ToString(urlParam[i]), param) == 0)
                {
                    value = urlParam[i + 1];
                    break;
                }
            }
            return value;
        }

        // GET: QuoteNew
        public ActionResult QuoteNew()
        {
            return View();
        }

        // GET: QuoteView
        public ActionResult QuoteView(string q)
        {
            // Set default
            var folderId = 0;
            var quoteId = 0;
            var quotePage = 1;
            var quotePageSize = 10;

            if (q != null)
            {
                //create querstring session
                Session["QuotesQueryString"] = q;

                folderId = Convert.ToInt16(QueryStringValue("fid"));
                quoteId = Convert.ToInt16(QueryStringValue("qid"));
                quotePage = Convert.ToInt16(QueryStringValue("qpn"));
                quotePageSize = Convert.ToInt16(QueryStringValue("qps"));
            }
            else
            {
                var membershipUser = Membership.GetUser(User.Identity.Name);
                //Get saved folder or first found folder
                HttpCookie folderCookie = Request.Cookies.Get("folder");
                if (folderCookie == null)
                {
                    folderId = unitOfWork.QuoteRepository.GetFoldersByUser((int)membershipUser.ProviderUserKey).OrderBy(x => x.name).First().folderId;
                    folderCookie = new HttpCookie("folder");
                    folderCookie.Value = folderId.ToString();
                    folderCookie.Expires = DateTime.Now.AddDays(360);
                    Response.Cookies.Add(folderCookie);
                }
                else
                {
                    folderId = Int16.Parse(folderCookie.Value);
                    folderCookie.Expires = DateTime.Now.AddDays(360);
                    Response.SetCookie(folderCookie);
                }
            }

            ViewData["SelectedFolderId"] = folderId;
            ViewData["SelectedQuoteId"] = quoteId;
            ViewData["SelectedQuotePage"] = quotePage;
            ViewData["QuotePageSize"] = quotePageSize;
           
                 return View();
        }

        #region QUOTE FOLDER
        // Return folder list view
       [HttpGet, OutputCache(Duration = 0)]
        public ActionResult FolderList()
        {
            return PartialView();
        }
        // Return json result of folder list
        [HttpGet, OutputCache(Duration = 0)]
        public JsonResult FolderList_Read()
        {
            // Retrieve user name
            var membershipUser = Membership.GetUser(User.Identity.Name);

            // Retrieve list of folders
            var folders = from q in unitOfWork.QuoteRepository.GetFoldersByUser((int)membershipUser.ProviderUserKey)
                          orderby q.name
                          select new 
                          {
                              folderId = q.folderId,
                              name = q.name
                          };
            return Json(folders, JsonRequestBehavior.AllowGet);
        }
        // Return create new folder view
        [HttpGet]
        public ActionResult FolderAdd()
        {
            return PartialView();
        }
        // Return rename folder view
        [HttpGet]
        public ActionResult FolderEdit(int id)
        {
            tbl_quotefolder quotefolder = unitOfWork.QuoteRepository.GetFolderByID(id);
            return PartialView(quotefolder);
        }
        // Delete a folder.
        [HttpGet]
        public ActionResult FolderDelete(int id)
        {
            //check for quotes assigned to folder
            var quotes = unitOfWork.QuoteRepository.GetQuotesByFolder(id);
            if (quotes.Any())
            {
                return new JsonResult
                {
                    Data = new
                    {
                        success = false,
                        view = "FolderList"
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                tbl_quotefolder quoteFolder = unitOfWork.QuoteRepository.GetFolderByID(id);
                if (ModelState.IsValid)
                {
                    unitOfWork.QuoteRepository.DeleteFolder(quoteFolder);
                    unitOfWork.Save();
                }
                return new JsonResult
                {
                    Data = new
                    {
                        success = true,
                        view = this.RenderPartialView("FolderList", quoteFolder)
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }

        }
        // Create a new folder
        [HttpPost]
        public ActionResult FolderAdd(tbl_quotefolder quoteFolder, string view)
        {
            var membershipUser = Membership.GetUser(User.Identity.Name);
            quoteFolder.userId = (int)membershipUser.ProviderUserKey;
            if (ModelState.IsValid)
            {
                //check for duplicate folder names
                var duplicateFolder = unitOfWork.QuoteRepository.GetFoldersByUser((int)membershipUser.ProviderUserKey).Where(q => q.name == quoteFolder.name);
                if (duplicateFolder != null && duplicateFolder.Any())
                {
                    return Json(new
                    {
                        folderId = quoteFolder.folderId,
                        name = "response",
                        success = false,
                        level = 2,
                        error = "A folder with this name already exists."
                    });
                }
                //Save the folder to database if ModelState is valid and no duplicates are found.
                switch (view)
                {
                    case "FolderNew":
                        unitOfWork.QuoteRepository.InsertFolder(quoteFolder);
                        break;
                    case "FolderEdit":
                        unitOfWork.QuoteRepository.UpdateFolder(quoteFolder);
                        break;
                }
                unitOfWork.Save();
                return Json(new
                {
                    folderId = quoteFolder.folderId,
                    success = true,
                });
            }
            else
            {
                return Json(new
                {
                    folderId = quoteFolder.folderId,
                    name = "response",
                    success = false,
                    level = 2,
                    error = "Folder name is invalid"

                });
            }
        }
        #endregion

        #region QUOTES

        // Return json result of folder list
        [HttpGet, OutputCache(Duration = 0)]
        public JsonResult QuoteTypeList_Read()
        {
            // Retrieve list of folders
            var quoteType = from q in unitOfWork.QuoteRepository.GetQuoteType()
                          orderby q.name
                          select new
                          {
                              folderId = q.quoteTypeId,
                              name = q.name
                          };
            return Json(quoteType, JsonRequestBehavior.AllowGet);
        }

        public ActionResult QuoteByUser_Read([DataSourceRequest] DataSourceRequest request, int Id)
        {
            return Json(GetQuotesByUser(Id).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<QuoteViewModel> GetQuotesByUser(int Id)
        {
            var membershipUser = Membership.GetUser(User.Identity.Name);
            return from quote in unitOfWork.QuoteRepository.GetQuotesByParam(Id, (int)membershipUser.ProviderUserKey).Distinct().ToList()
                   join quotestatus in unitOfWork.QuoteRepository.GetQuoteStatus() on quote.quoteStatusId equals quotestatus.quoteStatusId
                   join quotetype in unitOfWork.QuoteRepository.GetQuoteType() on quote.quoteTypeId equals quotetype.quoteTypeId
                   join customer in unitOfWork.QuoteRepository.GetCustomer() on quote.customerId equals customer.customerId
                   select new QuoteViewModel
                   {
                       quoteId = quote.quoteId,
                       name = quote.name,
                       customer = customer.name,
                       createdDate = quote.createdDate,
                       modifiedDate = quote.modifiedDate,
                       quoteStatus = quotestatus.name,
                       quoteType = quotetype.name
                   };
        }

        // Get: QuoteDetail
        public ActionResult QuoteDetail()
        {
            QuoteViewModel qvm = new QuoteViewModel();

            // Retrieve user name
            var membershipUser = Membership.GetUser(User.Identity.Name);
            qvm.owner = membershipUser.UserName;
            // Retrieve list of quote types
            qvm.QuoteTypeList = unitOfWork.QuoteRepository.GetQuoteType().ToList().Select(x => new SelectListItem
                {
                    Value = x.quoteTypeId.ToString(),
                    Text = x.name
                });
            // Retrieve list of customers
            qvm.CustomerList = unitOfWork.QuoteRepository.GetCustomer().ToList().Select(x => new SelectListItem
                {
                    Value = x.customerId.ToString(),
                    Text = x.name
                });
            // Created date
            qvm.createdDate = DateTime.Today;
            // Modified date
            qvm.modifiedDate = DateTime.Today;
            return PartialView(qvm);
                    
        }

        // Get: Return create quote view
        [HttpGet, OutputCache(Duration = 2592000, Location= OutputCacheLocation.Client)]
        public ActionResult QuoteAdd()
        {
            QuoteAddEditViewModel qaevm = new QuoteAddEditViewModel();
            var memberShipUser = Membership.GetUser(User.Identity.Name);
            var customer = from customers in unitOfWork.QuoteRepository.GetCustomer()
                           select new QuoteAddEditViewModel.Customer
                           {
                               customerId = customers.customerId,
                               alphaCode = customers.alphacode,
                               name = customers.name
                           };
            var currency = from currencies in unitOfWork.QuoteRepository.GetCurrency()
                           select new QuoteAddEditViewModel.Currency
                           {
                               currencyId = currencies.currencyId,
                               currency = currencies.currency
                           };
            var quoteStatus = from quoteStatuses in unitOfWork.QuoteRepository.GetQuoteStatus()
                              select new QuoteAddEditViewModel.QuoteStatus
                              {
                                  quoteStatusId = quoteStatuses.quoteStatusId,
                                  name = quoteStatuses.name
                              };
            var quoteType = from quoteTypes in unitOfWork.QuoteRepository.GetQuoteType()
                            select new QuoteAddEditViewModel.QuoteType
                            {
                                quoteTypeId = quoteTypes.quoteTypeId,
                                name = quoteTypes.name
                            };
            qaevm.Customers = customer.ToList();
            qaevm.Currencies = currency.ToList();
            qaevm.QuoteStatuses = quoteStatus.ToList();
            qaevm.QuoteTypes = quoteType.ToList();
            qaevm.createdDate = DateTime.Now;
            qaevm.modifiedDate = DateTime.Now;
            qaevm.owner = User.Identity.Name;
            qaevm.quoteTypeId = 1;
            qaevm.currencyId = 1;
            return PartialView(qaevm);
            

        }

        // Post: Add quote to database
        [HttpPost]
        public ActionResult QuoteAdd(QuoteAddEditViewModel qaevm)
        {
            //Create quote
            if(qaevm != null && ModelState.IsValid)
            {
                try
                {
                    tbl_quote quote = new tbl_quote();

                    var membershipUser = Membership.GetUser(User.Identity.Name);
                    quote.userId = (int)membershipUser.ProviderUserKey;
                    quote.customerId = qaevm.customerId ?? 0;
                    quote.folderId = qaevm.folderId;
                    quote.name = qaevm.name;
                    quote.owner = qaevm.owner;
                    quote.currencyId = qaevm.currencyId;
                    quote.quoteStatusId = qaevm.quoteStatusId;
                    quote.quoteTypeId = qaevm.quoteTypeId;
                    quote.createdDate = qaevm.createdDate;
                    quote.modifiedDate = qaevm.modifiedDate;
                    quote.quoteCancelled = false;
                    quote.firmQuote = false;
                    quote.contactFirstName = qaevm.contactFirstName;
                    quote.contactLastName = qaevm.contactLastName;
                    unitOfWork.QuoteRepository.AddQuote(quote);
                    unitOfWork.Save();
                    return JavaScript("onQuote_Add('" + quote.folderId + "')");
               }
                catch (Exception e)
                {
                    return Json(new
                        {
                            name = "response",
                            success = false,
                            level = 2,
                            error = "Error while adding quote: " + e.Message
                        });
                }
            }
            return Json(new
            {
                name = "response",
                success = false,
                level = 2,
                error = "Invalid data. Please check that all required data has been entered."
            });
        }

        // Post: Return edit quote view
        [HttpPost]
        public ActionResult QuoteEdit(int id)
        {
            tbl_quote quote = unitOfWork.QuoteRepository.GetQuoteByID(id);
            var customer = from customers in unitOfWork.QuoteRepository.GetCustomer()
                           select new QuoteAddEditViewModel.Customer
                           {
                               customerId = customers.customerId,
                               alphaCode = customers.alphacode,
                               name = customers.name
                           };
            var currency = from currencies in unitOfWork.QuoteRepository.GetCurrency()
                           select new QuoteAddEditViewModel.Currency
                           {
                               currencyId = currencies.currencyId,
                               currency = currencies.currency
                           };
            var quoteStatus = from quoteStatuses in unitOfWork.QuoteRepository.GetQuoteStatus()
                              select new QuoteAddEditViewModel.QuoteStatus
                              {
                                  quoteStatusId = quoteStatuses.quoteStatusId,
                                  name = quoteStatuses.name
                              };
            var quoteType = from quoteTypes in unitOfWork.QuoteRepository.GetQuoteType()
                            select new QuoteAddEditViewModel.QuoteType
                            {
                                quoteTypeId = quoteTypes.quoteTypeId,
                                name = quoteTypes.name
                            };
            QuoteAddEditViewModel qaevm = new QuoteAddEditViewModel();
            
            qaevm.Customers = customer.ToList();
            qaevm.Currencies = currency.ToList();
            qaevm.QuoteStatuses = quoteStatus.ToList();
            qaevm.QuoteTypes = quoteType.ToList();
            qaevm.quoteId = id;
            qaevm.userId = quote.userId;
            qaevm.customerId = quote.customerId;
            qaevm.folderId = quote.folderId;
            qaevm.createdDate = quote.createdDate;
            qaevm.modifiedDate = quote.modifiedDate;
            qaevm.name = quote.name;
            qaevm.owner = quote.owner;
            qaevm.contactFirstName = quote.contactFirstName;
            qaevm.contactLastName = quote.contactLastName;
            qaevm.quoteStatusId = quote.quoteStatusId;
            qaevm.quoteTypeId = quote.quoteTypeId;
            qaevm.currencyId = quote.currencyId;
            
            
            return PartialView(qaevm);
        }

        [HttpPost]
        public ActionResult QuoteEditSave(QuoteAddEditViewModel qaevm)
        {
            if (qaevm != null && ModelState.IsValid)
            {
                try
                {
                    tbl_quote quote = unitOfWork.QuoteRepository.GetQuoteByID(qaevm.quoteId);
                    quote.customerId = qaevm.customerId ?? 0;
                    quote.folderId = qaevm.folderId;
                    quote.name = qaevm.name;
                    quote.owner = qaevm.owner;
                    quote.currencyId = qaevm.currencyId;
                    quote.contactFirstName = qaevm.contactFirstName;
                    quote.contactLastName = qaevm.contactLastName;
                    quote.quoteStatusId = qaevm.quoteStatusId;
                    quote.quoteTypeId = qaevm.quoteTypeId;
                    quote.modifiedDate = qaevm.modifiedDate;

                    unitOfWork.QuoteRepository.UpdateQuote(quote);
                    unitOfWork.Save();

                    return JavaScript("onQuote_Add('" + quote.folderId + "')");
                   
                }
                catch (Exception e)
                {
                    return Json(new
                    {
                        name = "response",
                        success = false,
                        level = 2,
                        error = "Error while editing quote: " + e.Message
                    });
                }
            }
            return Json(new
            {
                name = "response",
                success = false,
                level = 2,
                error = "Invalid data. Please check that all required data has been entered."
            });
        }

        private void UpdateQuoteModifiedDate(int quoteId)
        {
            tbl_quote quote = unitOfWork.QuoteRepository.GetQuoteByID(quoteId);
            quote.modifiedDate = DateTime.Now;
            //Save modification to database
            unitOfWork.QuoteRepository.UpdateQuote(quote);
            unitOfWork.Save();
        }

        #endregion

        #region PRODUCTS
        [HttpGet]
        public ActionResult ProductAdd(int id)
        {
            List<ProductFamilyViewModel> pf = new List<ProductFamilyViewModel>();
            var product = from products in unitOfWork.QuoteRepository.GetProductFamily()
                          select new ProductFamilyViewModel
                          {
                              productFamilyId = products.productFamilyId,
                              name = products.name
                          };
            pf = product.ToList();
            ViewData["QuoteId"] = id;
            return PartialView(pf);
        }

        [HttpPost]
        public ActionResult ProductAdd(tbl_assignedproducts assignedProduct)
        {
            try
            {
                //check for duplicate service
                var duplicateService = unitOfWork.QuoteRepository.GetAssignedProducts(assignedProduct.quoteId).Where(x => x.productId == assignedProduct.productId);
                if (duplicateService.Any())
                {
                    return Json(new
                    {
                        name = "reponse",
                        success = false,
                        level = 1,
                        msg = "This service is already part of the quote"
                    });
                }
                // Check for matching currency
                //string currency = unitOfWork.ServiceRepository.GetPricebookByID(assignedService.pricebookId).currency;
                //foreach (var product in unitOfWork.QuoteRepository.GetAssignedProducts(assignedProduct.quoteId).ToList())
                //{
                //    if (currency != unitOfWork.ServiceRepository.GetPricebookByID(service.pricebookId).currency)
                //    {
                //        return Json(new
                //        {
                //            name = "reponse",
                //            success = false,
                //            level = 1,
                //            msg = "The price book currency doesn't match already added service currency."
                //        });
                //    }
                //}
                //Save values to database
                assignedProduct.discount = 0;
                unitOfWork.QuoteRepository.InsertAssignedProduct(assignedProduct);
                //update quote modified date
                tbl_quote quote = unitOfWork.QuoteRepository.GetQuoteByID(assignedProduct.quoteId);
                quote.modifiedDate = DateTime.Now;
                unitOfWork.Save();
            }
            catch (Exception e)
            {
                //Elmah.ErrorSignal.FromCurrentContext().Raise(e);
                return View("ErrorReport", new ErrorReportViewModel()
                {
                    actionName = "ServiceAdd(tbl_assignedservices)",
                    controllerName = "Quote",
                    message = "An unexpected error occured while adding service.",
                    exceptionType = e.GetType().Name,
                    exceptionMessage = e.Message,
                    time = DateTime.Now
                });
            }
            return Json(new
            {
                success = true,
                msg = "Service assigned."
            });
        }

        [HttpGet]
        public ActionResult ProductDelete(int id)
        {
            try
            {
                // 16.12.13 Foreign key added. Delete will cascades.
                // Delete assigned service
                unitOfWork.QuoteRepository.DeleteAssignedProduct(id);
                //Update quote modified date
                int quoteId = unitOfWork.QuoteRepository.GetAssignedProductByID(id).quoteId;
                tbl_quote quote = unitOfWork.QuoteRepository.GetQuoteByID(quoteId);
                quote.modifiedDate = DateTime.Now;
                unitOfWork.QuoteRepository.UpdateQuote(quote);
                // Save all changes
                unitOfWork.Save();
            }
            catch (Exception e)
            {
                //Elmah.ErrorSignal.FromCurrentContext().Raise(e);
                return View("ErrorReport", new ErrorReportViewModel()
                {
                    actionName = "ProductDelete(int)",
                    controllerName = "Quote",
                    message = "An unexpected error occured while deleting service.",
                    exceptionType = e.GetType().Name,
                    exceptionMessage = e.Message,
                    time = DateTime.Now
                });
            }
            return JavaScript("onProduct_Delete()");    
        }

        // Return json result of productfamily
        public ActionResult ProductFamily_Read()
        {
            return Json(unitOfWork.QuoteRepository.GetProductFamily().OrderBy(x => x.name).Select(x => new { productFamilyId = x.productFamilyId, name = x.name }), JsonRequestBehavior.AllowGet);
        }

        // Return json result of productgroup
        public ActionResult ProductGroup_Read(int productFamilyId)
        {
            return Json(unitOfWork.QuoteRepository.GetProductGroup(productFamilyId).OrderBy(x => x.name).Select(x => new { productGroupId = x.productGroupId, name = x.name }), JsonRequestBehavior.AllowGet);
        }

        // Return json result of products
        public ActionResult Product_Read(int productGroupId)
        {
            return Json(unitOfWork.QuoteRepository.GetProductByGroupId(productGroupId).OrderBy(x => x.name).Select(x => new { productId = x.productId, name = x.name }), JsonRequestBehavior.AllowGet);
        }

        //Return service Json result
        public ActionResult ProductList_Read([DataSourceRequest] DataSourceRequest request, int quoteId)
        {
            return Json(GetQuoteProducts(quoteId).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        //Retrieve Iemnumerable servcies result
        private IEnumerable<QuoteProductsViewModel> GetQuoteProducts(int Id)
        {
            return from assignedProduct in unitOfWork.QuoteRepository.GetAssignedProducts(Id)
                   join product in unitOfWork.QuoteRepository.GetProducts() on assignedProduct.productId equals product.productId
                   select new QuoteProductsViewModel
                   {
                       assignedProductId = assignedProduct.assignedProductId,
                       productId = assignedProduct.productId,
                       name = product.name,
                       controller = product.controller
                   };
        }

        [HttpPost]
        public ActionResult NavigateToProduct(int productid, int quotePageNumber, int quotePageSize, string pageName, string linkName, int folderId, int quoteId, bool isReadOnly)
        {
            UpdateQuoteModifiedDate(quoteId);
            string url = "pid=" + productid + "&qpn=" + quotePageNumber + "&qps=" + quotePageSize + "&pn=" + pageName + "&ln=" + linkName + "&fid=" + folderId + "&qid=" + quoteId + "&ro=" + isReadOnly;
            string encryptUrl = HttpUtility.UrlEncode(Security.EncryptString(url, true).ToString());
            return new JsonResult
            {
                Data = new { urlParam = "q=" + encryptUrl },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        #endregion

        

        

       
    }
}