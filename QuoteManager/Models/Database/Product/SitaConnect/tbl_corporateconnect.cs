using System.ComponentModel.DataAnnotations;

namespace QuoteManager.Models.Database.Product.SitaConnect
{
    public class tbl_corporateconnect
    {
        [Key]
        public int corporateConnectId { get; set; }
        public int assignedProductId { get; set; }
        public int siteId { get; set; }
        public int quoteId { get; set; }
        public int assetId { get; set; }
        public string country { get; set; }
        public string location { get; set; }
        public int townAirportId { get; set; }
        public bool existingSite { get; set; }
        public string bandwidth { get; set; }
        public string routerName { get; set; }
        public bool isp { get; set; }
        public string ispPrimaryBandwidth { get; set; }
        public string ispBackupBandwidth { get; set; }
        public string Satelite { get; set; }
        public string sateliteBackupBandwidth { get; set; }
        public bool access { get; set; }
        public bool sitaAirBackup { get; set; }
        public int? serviceNet1Id { get; set; }
        public int? serviceNet2Id { get; set; }
        public int? serviceNet3Id { get; set; }
        public bool siteQuickStart { get; set; }
        public string serviceDescription { get; set; }
        public bool accessNotRequired { get; set; }
        public string supplierCostFirm { get; set; }
        public string notes { get; set; }
        // User cost input
        public float ispOTC { get; set; }
        public float ispMRC { get; set; }
        public float accessOTC { get; set; }
        public float accessMRC { get; set; }
        public float hardwareOTC { get; set; }
        public float hardwareMRC { get; set; }
        public float serviceMngtOTC { get; set; }
        public float serviceMngtMRC { get; set; }  
        // OBS Cost totals    
        public float obsQuickStartSamOTC { get; set; }
        public float obsQuickStartSamMRC { get; set; }
        public float serviceOTP { get; set; }
        public bool serviceOTPOverride { get; set; }
        public float serviceOTPOverrideValue { get; set; }
        public float serviceMRP { get; set; }
        public bool serviceMRPOverride { get; set; }
        public float serviceMRPOverrideValue { get; set; }
        public float serviceMRPDiscountValue { get; set; }
        public string serviceMRPDiscountType { get; set; }
        public float serviceMRPDiscount { get; set; }
        public float quickConnectOTP { get; set; }
        public bool quickConnectOTPOverride { get; set; }
        public float quickConnectOTPValue { get; set; }
        public float quickConnectMRP { get; set; }
        public bool quickConnectMRPOverride { get; set; }
        public float quickConnectMRPValue { get; set; }
        public float disconnectionOTP { get; set; }
        public bool disconnectionOTPOverride { get; set; }
       public float disconnectionOTPValue { get; set; }
       public int comittedDuration { get; set; }
       public bool billabale { get; set; }
       public float grossMargin { get; set; }
       public float netMargin { get; set; }
        public bool includeInTotals { get; set; }

    }
}