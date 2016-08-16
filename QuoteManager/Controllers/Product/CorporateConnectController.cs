using System;
using System.Linq;
using System.Web.Mvc;
using QuoteManager.Dal;
using QuoteManager.Helpers;
using QuoteManager.Models.ViewModel.Product;
using QuoteManager.Models.ViewModel.Product.CorporateConnect;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

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

        // POST: /IpVpn/IpVpn_Read/
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CorporateConnect_Read([DataSourceRequest]DataSourceRequest request)
        {
            return Json(GetCorporateConnectGrid(Convert.ToInt16(QueryStringValue("pid"))).ToDataSourceResult(request, ModelState));
        }

        // Return Ip VPN grid records
        private IQueryable<CorporateConnectGridViewModel> GetCorporateConnectGrid(int assignedProductId)
        {
            return from corporateconnect in unitOfWork.CorporateConnectRepository.GetCorporateConnects(assignedProductId)
                   select new CorporateConnectGridViewModel
                   {

                       corporateConnectId = corporateconnect.corporateConnectId,
                       siteId = corporateconnect.siteId,
                       country = corporateconnect.country,
                       location = corporateconnect.location,
                       existingSite = corporateconnect.existingSite,
                       bandwidth = corporateconnect.bandwidth,
                       serviceDescription = corporateconnect.serviceDescription,
                       routerName = corporateconnect.routerName,
                       accessNotRequired = corporateconnect.accessNotRequired,
                       supplierCostFirm = corporateconnect.supplierCostFirm,
                       //serviceOTC = corporateconnect.ser,
                       //serviceMRC = corporateconnect.serviceMRC,
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

        #region BVPN WEB SERVICE

        [HttpPost]
        public JsonResult CallWebService(int scenarioId)
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
            // Retrieve current quote data
            
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

      

        #endregion

    }
}