using System.ComponentModel.DataAnnotations;

namespace QuoteManager.Models.Database.Product.SitaConnect
{
    public class tbl_corporateconnect
    {
        [Key]      
        public int corporateConnectId { get; set; }
        public int assignedProductId { get; set; }
        // OBS web service properties      
        public string siteId { get; set; }    
        public string countryCode { get; set; }       
        public string country { get; set; }              
        public string bandwidth { get; set; }
        // End OBS web service properties
        public int townAirportId { get; set; }
        public int assetId { get; set; }       
        public string location { get; set; }       
        public bool existingSite { get; set; }        
        public bool isp { get; set; }     
        public string ispPrimaryBandwidth { get; set; }
        public string ispBackupBandwidth { get; set; }      
        public bool access { get; set; }
        public string satellite { get; set; }
        public string satelliteBackupBandwidth { get; set; }
        public bool sitaAirBackup { get; set; }
        public int? serviceNet1Id { get; set; }
        public int? serviceNet2Id { get; set; }
        public int? serviceNet3Id { get; set; }
        public bool sitaQuickStart { get; set; }
        public string serviceDescription { get; set; }
        public string routerName { get; set; }
        public bool accessNotRequired { get; set; }
        public string supplierCostFirm { get; set; }
        public string notes { get; set; }
        // Cost elements
        public float quickConnectOTC { get; set; }
        public float quickConnectMRC { get; set; }
        public float serviceOTC { get; set; }
        public float serviceMRC { get; set; }
        public float ispOTC { get; set; }
        public float ispMRC { get; set; }
        public float accessOTC { get; set; }
        public float accessMRC { get; set; }
        public float hardwareOTC { get; set; }
        public float hardwareMRC { get; set; }
        public float serviceMngtOTC { get; set; }
        public float serviceMngtMRC { get; set; }
        public float serviceOTP { get; set; }
        public bool serviceOTPOverride { get; set; }
        public float serviceOTPOverrideValue { get; set; }
        public float serviceMRP { get; set; }
        public bool serviceMRPOverride { get; set; }
        public float serviceMRPOverrideValue { get; set; }
        public int serviceMRPDiscountValue { get; set; }
        public string serviceMRPDiscountType { get; set; }        
        public float serviceMRPDiscount { get; set; }       
        public float quickConnectOTP { get; set; }        
        public bool quickConnectOTPOverride { get; set; }       
        public float quickConnectOTPOverrideValue { get; set; }        
        public float quickConnectMRP { get; set; }        
        public bool quickConnectMRPOverride { get; set; }       
        public float quickConnectMRPOverrideValue { get; set; }       
        public float disconnectionOTP { get; set; }        
        public bool disconnectionOTPOverride { get; set; }       
        public float disconnectionOTPOverrideValue { get; set; }       
        public int committedDuration { get; set; }        
        public bool billable { get; set; }       
        public float grossMargin { get; set; }       
        public float netMargin { get; set; }
        public bool includeInTotals { get; set; }

    }
}