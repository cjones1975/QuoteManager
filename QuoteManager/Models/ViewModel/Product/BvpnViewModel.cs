using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuoteManager.Models.ViewModel.Product
{
    public class BvpnViewModel
    {
            public string scenarioId { get; set; }
            public string serviceCode { get; set; }
            public string approvalId { get; set; }
            public int endUserId { get; set; }
            public string endUserName { get; set; }
            public string bidOwner { get; set; }
            public string contractTerm { get; set; }
            public string currency { get; set; }
            public DateTime expiryDate { get; set; }
       

        public class BvpnLineItem
        {
            public string primaryISOCountry { get; set; }
            public string siteName { get; set; }
            public string primarySiteCity { get; set; }
            public string primarySitePhone { get; set; }
            public string primarySiteAddress { get; set; }
            public string primarySiteBuilding { get; set; }
            public string primarySiteContact { get; set; }
            public string country { get; set; }
            public string siteProfile { get; set; }
        }

        public List<BvpnLineItem> LineItem { get; set; }

    }
}