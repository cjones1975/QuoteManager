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
            public string lineData { get; set; }
            public string siteName { get; set; }
            public string primaryISOCountry { get; set; }
            public string country { get; set; }
            public string bandwidth { get; set; }
            //Charge elments
            public float cosMRC { get; set; }
            public float cosOTC { get; set; }
            public float secondCosMRC { get; set; }
            public float secondCosOTP { get; set; }
            public float totalMRP { get; set; }
            public float totalOTP { get; set; }
            public float samBrickMRP { get; set; }
            public float samBrickOTP { get; set; }
            public float primaryQuoteLMRP { get; set; }
            public float primaryLocalLoopMRP { get; set; }
            public float primaryLocalLoopOTP { get; set; }
            public float secondaryQuoteLMRP { get; set; }
            public float secondaryLocalLoopMRP { get; set; }
            public float secondaryLocalLoopOTP { get; set; }
            public float airQuickStartMRP { get; set; }
            public float airQuickStartOTP { get; set; }
            public float rtVoiceListMRP { get; set; }
            public float rtVideoListMRP { get; set; }
            public float busTalkListMRP { get; set; }
            public float serviceMRP { get; set; }
            public float telepresenceConnectMRP { get; set; }
            public float advancedFeaturesMRP { get; set; }
            public float continuityMRP { get; set; }
            public float internetMRP { get; set; }
            public float serviceListOTP { get; set; }
            public float networkSiteSurveyListOTP { get; set; }
            public float advancedFeaturesListOTP { get; set; }
            public float continuityListOTP { get; set; }
            public float ONBHInstallationListOTP { get; set; }
            public float internetListOTP { get; set; }
            public float mrpRelatingToAmortizedOTP { get; set; }
            public float primaryVpnBandwidthMRP { get; set; }
            public float secondaryVpnBandwidthMRP { get; set; }
            public float primaryFlexibleCosMRP { get; set; }
            public float secondaryFlexibleCosMRP { get; set; }
            public float primaryRtPremiumMRP { get; set; }
            public float secondaryRtPremiumMRP { get; set; }
            public float primaryVirtualPlugMRP { get; set; }
            public float secondaryVirtualPlugMRP { get; set; }
            public float primaryVirtualPlugOTP { get; set; }
            public float secondaryVirtualPlugOTP { get; set; }
            public float primaryValuenetForcedMRP { get; set; }
            public float primaryAndSecondaryCascadedRTOTP { get; set; }
            public float primaryVrCustomerCareMRP { get; set; }
            public float primaryInternetUsageMRP { get; set; }
            public float secondaryInternetUsageMRP { get; set; }
            public float primaryAndSecondaryInternetUsageOTP { get; set; }
            public float cascaded1MRP { get; set; }
            public float cpe1HardwareMRP { get; set; }
            public float totalCascaded1MRP { get; set; }
            public float cascadedInstallation1OTP { get; set; }
            public float cascaded2MRP { get; set; }
            public float cpe2HardwareMRP { get; set; }
            public float totalCascaded2MRP { get; set; }
            public float cascadedInstallation2OTP { get; set; }
            public float cascaded3MRP { get; set; }
            public float cpe3HardwareMRP { get; set; }
            public float totalCascaded3MRP { get; set; }
            public float cascadedInstallation3OTP { get; set; }
            public float cascaded4MRP { get; set; }
            public float cpe4hardwareMRP { get; set; }
            public float totalCascaded4MRP { get; set; }
            public float cascadedInstallation4OTP { get; set; }
            
        }

        public List<BvpnLineItem> LineItem { get; set; }

    }
}