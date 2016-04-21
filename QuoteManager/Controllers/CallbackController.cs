using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using Salesforce.Common;
using System.Threading.Tasks;

namespace QuoteManager.Controllers
{
    public class CallbackController : ApiController
    {
        private readonly string consumerKey = ConfigurationManager.AppSettings["ConsumerKey"];
        private readonly string consumerSecret = ConfigurationManager.AppSettings["ConsumerSecret"];
        private readonly string callbackUrl = ConfigurationManager.AppSettings["CallbackUrl"];
        private readonly string tokenRequestEndpointUrl = ConfigurationManager.AppSettings["TokenRequestEndpointUrl"];

            [HttpGet]
            public async Task<HttpResponseMessage> Get(string display, string code)
            {
                var auth = new AuthenticationClient();
                await auth.WebServerAsync(consumerKey,consumerSecret,callbackUrl,code,tokenRequestEndpointUrl);

                var url = string.Format("/?token={0}&api={1}&instance_url={2}", auth.AccessToken, auth.ApiVersion, auth.InstanceUrl);

                var response = new HttpResponseMessage(HttpStatusCode.Redirect);
                response.Headers.Location = new Uri(url, UriKind.Relative);
                return response;
            }
    }
}
