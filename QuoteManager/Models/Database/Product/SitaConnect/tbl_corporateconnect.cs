using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuoteManager.Models.Database.Product.SitaConnect
{
    public class tbl_corporateconnect
    {
        public int lineId { get; set; }
        public int siteId { get; set; }
        public int quoteId { get; set; }
        public int assetId { get; set; }
        public string countryId { get; set; }
        public string location { get; set; }
        public int townAirportId { get; set; }
        public bool existingSite { get; set; }
        public string bandwidth { get; set; }
        public string ispPrimaryBandwidth { get; set; }
        public string ispBackupBandwidth { get; set; }
        public string Satelite { get; set; }
        public string sateliteBackupBandwidth { get; set; }
        public bool sitaAirBackup { get; set; }
        public int? serviceNet1Id { get; set; }
        public int? serviceNet2Id { get; set; }
        public int? serviceNet3Id { get; set; }
        public bool siteQuickStart { get; set; }
        public bool access { get; set; }
        public string serviceDescription { get; set; }
        public string routerName { get; set; }
        public bool accessNotRequired { get; set; }
        public string supplierCostFirm { get; set; }
        public string notes { get; set; }
        public float ispOTC { get; set; }
        public float ispMRC { get; set; }
        public float accessOTC { get; set; }
        public float accessMRC { get; set; }
        public float hardwareOTC { get; set; }
        public float hardwareMRC { get; set; }
        //OBS one time costs
        public float serviceOTC { get; set; }
        public float primaryLocalLoopOTC { get; set; }
        public float secondaryLocalLoopOTC { get; set; }
        public float rtVoiceOTC { get; set; }
        public float advancedFeaturesOTC { get; set; }
        public float continuityOTC { get; set; }
        public float internetOTC { get; set; }
        public float networkSiteSurveyOTC { get; set; }
        public float onbhInstallationOTC { get; set; }
        public float cosOTC { get; set; }
        public float secondCosOTC { get; set; }
        public float samBrickOTC { get; set; }
        //OBS reacurring costs
        public float serviceMRC { get; set; }
        public float primaryLocalLoopMRC { get; set; }
        public float secondaryLocalLoopMRC { get; set; }
        public float rtVoiceMRC { get; set; }
        public float advancedFeaturesMRC { get; set; }
        public float continuityMRC { get; set; }
        public float internetMRC { get; set; }
        public float businessTalkMRC { get; set; }
        public float telePresenceConnectMRC { get; set; }
        public float cosMRC { get; set; }
        public float secondCosMRC { get; set; }
        public float samBrickMRC { get; set; }

    }
}