using System;
using System.Linq;
using System.Web.Mvc;
using QuoteManager.Dal;
using QuoteManager.Helpers;
using QuoteManager.Models.Database.Product.SitaConnect;
using QuoteManager.Models.ViewModel.Product;
using QuoteManager.Models.ViewModel.Product.CorporateConnect;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Collections.Generic;

namespace QuoteManager.Controllers.Product
{
    public class CorporateConnectController : Controller
    {
        private readonly UnitOfWork unitOfWork = new UnitOfWork();

        private object QueryStringValue(string param)
        {
            object value = null;
            string qs = Security.DecryptString((String)Session["CorporateConnectQueryString"], true);
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

        // GET: CoporateConnect
        public ActionResult Index(string q)
        {
            Session["CorporateConnectQueryString"] = q;

            var assignedProductId = Convert.ToInt16(QueryStringValue("pid"));
            ViewBag.linkName = QueryStringValue("ln");
            ViewBag.pageName = QueryStringValue("pn");
            ViewData["isReadOnly"] = Convert.ToBoolean(QueryStringValue("ro"));
            ViewData["Submit"] = "Add Site";
            ViewData["Currency"] = "USD";
            return View();
        }

        // POST: /CorporateConnect/CorporateConnect_Read/
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CorporateConnect_Read([DataSourceRequest]DataSourceRequest request)
        {
            return Json(GetCorporateConnectGrid(Convert.ToInt16(QueryStringValue("pid"))).ToDataSourceResult(request, ModelState));
        }

        // Return CorporateConnect grid records
        private IQueryable<CorporateConnectGridViewModel> GetCorporateConnectGrid(int assignedProductId)
        {
            return from corporateconnect in unitOfWork.CorporateConnectRepository.GetCorporateConnects(assignedProductId)
                   select new CorporateConnectGridViewModel
                   {

                       corporateConnectId = corporateconnect.corporateConnectId,
                       siteId = corporateconnect.siteId,
                       countryCode = corporateconnect.countryCode,
                       country = corporateconnect.country,
                       location = corporateconnect.location,
                       existingSite = corporateconnect.existingSite,
                       bandwidth = corporateconnect.bandwidth,
                       serviceDescription = corporateconnect.serviceDescription,
                       routerName = corporateconnect.routerName,
                       accessNotRequired = corporateconnect.accessNotRequired,
                       supplierCostFirm = corporateconnect.supplierCostFirm,
                       isp = corporateconnect.isp,
                       ispPrimaryBandwidth = corporateconnect.ispPrimaryBandwidth,
                       ispBackupBandwidth = corporateconnect.ispBackupBandwidth,
                       access = corporateconnect.access,
                       Satellite = corporateconnect.satellite,
                       satelliteBackupBandwidth = corporateconnect.satelliteBackupBandwidth,
                       sitaAirBackup = corporateconnect.sitaAirBackup,
                       serviceNet1Id = corporateconnect.serviceNet1Id,
                       serviceNet2Id = corporateconnect.serviceNet2Id,
                       serviceNet3Id = corporateconnect.serviceNet3Id,
                       committedDuration = corporateconnect.committedDuration,
                       billable = corporateconnect.billable,
                       grossMargin = corporateconnect.grossMargin,
                       netMargin = corporateconnect.netMargin,
                       includeInTotals = corporateconnect.includeInTotals,
                       ispOTC = corporateconnect.ispOTC,
                       ispMRC = corporateconnect.ispMRC,
                       accessOTC = corporateconnect.accessOTC,
                       accessMRC = corporateconnect.accessMRC,
                       hardwareOTC = corporateconnect.hardwareOTC,
                       hardwareMRC = corporateconnect.hardwareMRC,

                       
                       
                       //setupCharges = ipvpn.bandwidthSetupCharge + ipvpn.optionSetupCharge + ipvpn.accessSetupCharge,
                       //monthlyCharges = ipvpn.bandwidthMonthlyCharge + ipvpn.optionMonthlyCharge + ipvpn.accessMonthlyCharge
                   };
        }

        // GET: /CorporateConnect/CorporateConnect_Select
        public ActionResult CorporateConnect_Select(int id)
        {
            var corporateconnect = GetCorporateConnect(id);
            return Json(new
            {
                corporateConnectId = corporateconnect.corporateConnectId,
                existingSite = corporateconnect.existingSite,
                routerName = corporateconnect.routerName,
                isp = corporateconnect.isp,
                ispPrimaryBandwidth = corporateconnect.ispPrimaryBandwidth,
                ispBackupBandwidth = corporateconnect.ispBackupBandwidth,
                satellite = corporateconnect.satellite,
                satelliteBackupBandwidth = corporateconnect.satelliteBackupBandwidth,
                sitaAirBackup = corporateconnect.sitaAirBackup,
                serviceNet1Id = corporateconnect.serviceNet1Id,
                serviceNet2Id = corporateconnect.serviceNet2Id,
                serviceNet3Id = corporateconnect.serviceNet3Id,
                sitaQuickStart = corporateconnect.sitaQuickStart,
                ispOTC = corporateconnect.ispOTC,
                ispMRC = corporateconnect.ispMRC,
                accessOTC = corporateconnect.accessOTC,
                accessMRC = corporateconnect.accessMRC,
                hardwareOTC = corporateconnect.hardwareOTC,
                hardwareMRC = corporateconnect.hardwareMRC,
                serviceMngtOTC = corporateconnect.serviceMngtOTC,
                serviceMngtMRC = corporateconnect.serviceMngtMRC,
                serviceMRPOverrideValue = corporateconnect.serviceMRPOverrideValue,
                serviceMRPDiscountType = corporateconnect.serviceMRPDiscountType
            }, JsonRequestBehavior.AllowGet);
        }

        // Return the corporateconnect site
        private CorporateConnectViewModel GetCorporateConnect(int corporateConnectId)
        {
            var corporateconnect = unitOfWork.CorporateConnectRepository.GetCorporateConnectById(corporateConnectId);
            return new CorporateConnectViewModel()
            {
                corporateConnectId = corporateconnect.corporateConnectId,
                existingSite = corporateconnect.existingSite,
                routerName = corporateconnect.routerName,
                isp = corporateconnect.isp,
                ispPrimaryBandwidth = corporateconnect.ispPrimaryBandwidth,
                ispBackupBandwidth = corporateconnect.ispBackupBandwidth,
                satellite = corporateconnect.satellite,
                satelliteBackupBandwidth = corporateconnect.satelliteBackupBandwidth,
                sitaAirBackup = corporateconnect.sitaAirBackup,
                serviceNet1Id = corporateconnect.serviceNet1Id,
                serviceNet2Id = corporateconnect.serviceNet2Id,
                serviceNet3Id = corporateconnect.serviceNet3Id,
                sitaQuickStart = corporateconnect.sitaQuickStart,
                ispOTC = corporateconnect.ispOTC,
                ispMRC = corporateconnect.ispMRC,
                accessOTC = corporateconnect.accessOTC,
                accessMRC = corporateconnect.accessMRC,
                hardwareOTC = corporateconnect.hardwareOTC,
                hardwareMRC = corporateconnect.hardwareMRC,
                serviceMngtOTC = corporateconnect.serviceMngtOTC,
                serviceMngtMRC = corporateconnect.serviceMngtMRC,
                serviceMRPOverrideValue = corporateconnect.serviceMRPOverrideValue,
                serviceMRPDiscountType = corporateconnect.serviceMRPDiscountType
            };
        }

        // POST: /CorporateConnect/CorporateConnect_Edit
        public ActionResult CorporateConnect_Edit(CorporateConnectViewModel model)
        {
            if(ModelState.IsValid && model != null)
            {
                try
                {
                    tbl_corporateconnect corporateconnect = unitOfWork.CorporateConnectRepository.GetCorporateConnectById(model.corporateConnectId);
                    corporateconnect.existingSite = model.existingSite;
                    corporateconnect.routerName = model.routerName;
                    corporateconnect.isp = model.isp;
                    corporateconnect.ispPrimaryBandwidth = model.ispPrimaryBandwidth;
                    corporateconnect.ispBackupBandwidth = model.ispBackupBandwidth;
                    corporateconnect.satellite = model.satellite;
                    corporateconnect.satelliteBackupBandwidth = model.satelliteBackupBandwidth;
                    corporateconnect.sitaAirBackup = model.sitaAirBackup;
                    corporateconnect.serviceNet1Id = model.serviceNet1Id;
                    corporateconnect.serviceNet2Id = model.serviceNet2Id;
                    corporateconnect.serviceNet3Id = model.serviceNet3Id;
                    corporateconnect.sitaQuickStart = model.sitaQuickStart;
                    corporateconnect.ispOTC = model.ispOTC;
                    corporateconnect.ispMRC = model.ispMRC;
                    corporateconnect.accessOTC = model.accessOTC;
                    corporateconnect.accessMRC = model.accessMRC;
                    corporateconnect.hardwareOTC = model.hardwareOTC;
                    corporateconnect.hardwareMRC = model.hardwareMRC;
                    corporateconnect.serviceMngtOTC = model.serviceMngtOTC;
                    corporateconnect.serviceMngtMRC = model.serviceMngtMRC;
                    corporateconnect.serviceMRPDiscountValue = model.servcieMRPDiscountValue;
                    corporateconnect.serviceMRPDiscountType = model.serviceMRPDiscountType;

                    unitOfWork.CorporateConnectRepository.UpdateCorporateConnect(corporateconnect);
                    unitOfWork.Save();



                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "An error occured. Please verify the data");
                }
            }
            return Json(ModelState.ToDataSourceResult(), JsonRequestBehavior.AllowGet);
        }

        // ELEMENT LISTS

        // GET: /Product/CountryList
        public ActionResult CountryList()
        {
            return Json(GetCountries().OrderBy(x => x.name), JsonRequestBehavior.AllowGet);
        }

        // Return list of countries
        private IQueryable<CountryViewModel> GetCountries()
        {
            return from country in unitOfWork.ProductRepository.GetCountries()
                   select new CountryViewModel
                   {
                       countryId = country.countryId,
                       name = country.name
                   };
        }

        // GET: /Product/ServiceNetList1
        public ActionResult ServiceNetList1()
        {
            return Json(GetServiceNet1().OrderBy(x => x.name), JsonRequestBehavior.AllowGet);
        }

        // Return list of serviceNets
        public IQueryable<ServiceNet1ViewModel> GetServiceNet1()
        {
            return from serviceNet in unitOfWork.ProductRepository.GetServiceNets()
                   select new ServiceNet1ViewModel
                   {
                       serviceNet1Id = serviceNet.serviceNetId,
                       name = serviceNet.name
                   };
        }

        // GET: /Product/ServiceNetList2
        public ActionResult ServiceNetList2()
        {
            return Json(GetServiceNet2().OrderBy(x => x.name), JsonRequestBehavior.AllowGet);
        }

        // Return list of serviceNets
        public IQueryable<ServiceNet2ViewModel> GetServiceNet2()
        {
            return from serviceNet in unitOfWork.ProductRepository.GetServiceNets()
                   select new ServiceNet2ViewModel
                   {
                       serviceNet2Id = serviceNet.serviceNetId,
                       name = serviceNet.name
                   };
        }

        // GET: /Product/ServiceNetList3
        public ActionResult ServiceNetList3()
        {
            return Json(GetServiceNet3().OrderBy(x => x.name), JsonRequestBehavior.AllowGet);
        }

        // Return list of serviceNets
        public IQueryable<ServiceNet3ViewModel> GetServiceNet3()
        {
            return from serviceNet in unitOfWork.ProductRepository.GetServiceNets()
                   select new ServiceNet3ViewModel
                   {
                       serviceNet3Id = serviceNet.serviceNetId,
                       name = serviceNet.name
                   };
        }
        #region BVPN WEB SERVICE

        [HttpPost]
        public JsonResult CallWebService(string scenarioId)
        {
            var assignedProductId = Convert.ToInt16(QueryStringValue("pid"));
            // Call WebService
            string payload = @"C:\\Users\\cjones\\Documents\\webservice_response_BVPN.xml";
            // Remove illigal characters from xml data
            string fileContent = System.IO.File.ReadAllText(payload);
            XmlMethods xs = new XmlMethods();
            xs.SanitizeXmlString(fileContent);
            // Iterate data and fill model
            BvpnViewModel bvpnModel = new BvpnViewModel();
            bvpnModel = xs.parseBvpnXmlData(fileContent);
           

            if (!unitOfWork.CorporateConnectRepository.HasCorporateConnects(assignedProductId))
            {
                // Create new sites
                foreach (BvpnViewModel.BvpnLineItem line in bvpnModel.LineItem)
                {
                    tbl_corporateconnect corporateconnect = new tbl_corporateconnect();
                    corporateconnect.assignedProductId = assignedProductId;
                    corporateconnect.siteId = line.siteName;
                    corporateconnect.country = line.country;
                    corporateconnect.countryCode = line.primaryISOCountry;
                    corporateconnect.location = "n/a";
                    corporateconnect.townAirportId = 1;
                    corporateconnect.bandwidth = line.bandwidth;
                    corporateconnect.existingSite = false;
                    corporateconnect.isp = false;
                    corporateconnect.access = false;
                    corporateconnect.serviceNet1Id = 0;
                    corporateconnect.serviceNet2Id = 0;
                    corporateconnect.serviceNet3Id = 0;
                    corporateconnect.sitaQuickStart = false;
                    corporateconnect.sitaAirBackup = false;
                    corporateconnect.supplierCostFirm = "Budgetary";
                    corporateconnect.billable = true;
                    corporateconnect.includeInTotals = true;
                    corporateconnect.serviceMRPDiscountType = "%";
                    corporateconnect.committedDuration = Convert.ToInt16(bvpnModel.contractTerm.Substring(0,2));
                    corporateconnect.serviceOTC = line.cosOTC + line.secondCosOTC + line.totalOTP;
                    corporateconnect.serviceMRC = line.cosMRC + line.secondCosMRC + line.totalMRP;
                    try
                    {
                        unitOfWork.CorporateConnectRepository.AddCorporateConnect(corporateconnect);
                        unitOfWork.Save();
                    }
                    catch(Exception ex)
                    {

                    }
                }
                
            }
            else
            {
                // Recuperate existing sites by matching the site name

            }
            // Update scenarioId
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

      

        #endregion

    }
}