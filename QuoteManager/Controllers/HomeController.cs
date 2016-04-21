using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Threading.Tasks;
using Salesforce.Common;
using Salesforce.Common.Models;
using Salesforce.Force;
using QuoteManager.Models.ViewModel.Home;

namespace QuoteManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly string authorizationEndpointUrl = ConfigurationManager.AppSettings["AuthorizationEndPointUrl"];
        private readonly string consumerKey = ConfigurationManager.AppSettings["ConsumerKey"];
        private readonly string consumerSecret = ConfigurationManager.AppSettings["ConsumerSecret"];
        private readonly string sfdc_username = ConfigurationManager.AppSettings["sfdc_username"];
        private readonly string sfdc_password = ConfigurationManager.AppSettings["sfdc_password"];
        private readonly string sfdc_token = ConfigurationManager.AppSettings["sfdc_token"];

        public ActionResult Index()
        {
            SFDCAuth();
            return View();
        }

        private async Task SFDCAuth()
        {
            var auth = new AuthenticationClient();
            try
            {
                await auth.UsernamePasswordAsync(consumerKey, consumerSecret, sfdc_username, sfdc_password + sfdc_token);
            }
            catch (ForceAuthException e)
            {

            }
            try
            {
                var client = new ForceClient(auth.InstanceUrl, auth.AccessToken, auth.ApiVersion);
                var opportunities = await client.QueryAsync<dynamic>("SELECT Name from Contacts");
                foreach (dynamic opp in opportunities.Records)
                {
                    Console.WriteLine(opp.name);
                }
            }
            catch(ForceException e)
            {
                string error = e.Message;
            }
        }

        

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}