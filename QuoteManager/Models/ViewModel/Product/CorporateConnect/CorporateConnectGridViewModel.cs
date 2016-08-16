using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuoteManager.Models.ViewModel.Product.CorporateConnect
{
    public class CorporateConnectGridViewModel
    {
        [Key]
        public int corporateConnectId { get; set; }
        public int assignedProductId { get; set; }
        // OBS web service properties
        [Display(Name = "Site Name")]
        public int siteId { get; set; }
         
        [Display(Name = "Country Code")]
        public string countryCode { get; set; }
              
        [Display(Name = "Country")]
        public string country { get; set; }

        [Display(Name = "Bandwidth")]
        public string bandwidth { get; set; }
        // End OBS web service properties
        public int assetId { get; set; }

        [Display(Name = "Location")]
        public string location { get; set; }

        [Display(Name = "Existing Site?")]
        public bool existingSite { get; set; }
       
        [Display(Name = "ISP")]
        public bool isp { get; set; }

        [Display(Name = "ISP Primary Bandwidth")]
        public string ispPrimaryBandwidth { get; set; }

        [Display(Name = "ISP Backup Bandwidth")]
        public string ispBackupBandwidth { get; set; }

        [Display(Name = "Access")]
        public bool access { get; set; }

        [Display(Name = "Satelite")]
        public string Satelite { get; set; }

        [Display(Name = "Satelite Backup Bandwidth")]
        public string sateliteBackupBandwidth { get; set; }

        [Display(Name = "SITA AirBackup?")]
        public bool sitaAirBackup { get; set; }

        [Display(Name = "ServiceNet 1")]
        public int? serviceNet1Id { get; set; }

        [Display(Name = "ServiceNet 2")]
        public int? serviceNet2Id { get; set; }
        [Display(Name = "ServiceNet 3")]
        public int? serviceNet3Id { get; set; }
        [Display(Name = "SITA QuickStart?")]
        public bool siteQuickStart { get; set; }
        [Display(Name = "Service Description")]
        public string serviceDescription { get; set; }
        [Display(Name = "Router Name")]
        public string routerName { get; set; }
        [Display(Name = "Access Required")]
        public bool accessNotRequired { get; set; }
        [Display(Name = "Supplier Costs Firm?")]
        public string supplierCostFirm { get; set; }
        [Display(Name = "Notes")]
        public string notes { get; set; }
        // Cost elements
        [Display(Name = "QuickConnect OTC")]
        public float quickConnectOTC { get; set; }
        [Display(Name = "QuickConnect MRC")]
        public float quickConnectMRC { get; set; }
        [Display(Name = "Service OTC")]
        public float serviceOTC { get; set; }
        [Display(Name = "Service MRC")]
        public float serviceMRC { get; set; }
        [Display(Name = "ISP OTC")]
        public float ispOTC { get; set; }
        [Display(Name = "ISP MRC")]
        public float ispMRC { get; set; }
        [Display(Name = "Access OTC")]
        public float accessOTC { get; set; }
        [Display(Name = "Access MRC")]
        public float accessMRC { get; set; }
        [Display(Name = "Hardware OTC")]
        public float hardwareOTC { get; set; }
        [Display(Name = "Hardware MRC")]
        public float hardwareMRC { get; set; }
        [Display(Name = "Service Mgnt. OTC")]
        public float serviceMngtOTC { get; set; }
        [Display(Name = "Service Mgnt. MRC")]
        public float serviceMngtMRC { get; set; }
        [Display(Name = "Service OTP")]
        public float serviceOTP { get; set; }
        [Display(Name = "Service OTP Override?")]
        public bool serviceOTPOverride { get; set; }
        [Display(Name = "Service OTP Override Value")]
        public float serviceOTPOverrideValue { get; set; }
        [Display(Name = "Service MRP")]
        public float serviceMRP { get; set; }
        [Display(Name = "Service MRP Override?")]
        public bool serviceMRPOverride { get; set; }
        [Display(Name = "Service MRP Override Value")]
        public float serviceMRPOverrideValue { get; set; }
        [Display(Name = "Service MRP Discount Value")]
        public int servcieMRPDiscountValue { get; set; }
        [Display(Name = "Service MRP Discount Type")]
        public string serviceMRPDiscountType { get; set; }
        [Display(Name = "Service MRP Discount")]
        public float serviceMRPDiscount { get; set; }
        [Display(Name = "QuickConnect OTP")]
        public float quickConnectOTP { get; set; }
        [Display(Name = "QuickConnect OTP Override")]
        public bool quickConnectOTPOverride { get; set; }
        [Display(Name = "QuickConnect Override Value")]
        public float quickConnectOTPOverrideValue { get; set; }
        [Display(Name = "QuickConnect MRP")]
        public float quickConnectMRP { get; set; }
        [Display(Name = "QuickConnect MRP Override?")]
        public bool quickConnectMRPOverride { get; set; }
        [Display(Name = "QuickConnect MRP Override Value")]
        public float quickConnectMRPOverrideValue { get; set; }
        [Display(Name = "Disconnection OTP")]
        public float disconnectionOTP { get; set; }
        [Display(Name = "Disconnection OTP Override?")]
        public bool disconnectionOTPOverride { get; set; }
        [Display(Name = "Disconnection Override Value")]
        public float disconnectionOverrideValue { get; set; }
        [Display(Name = "Committed Duration")]
        public int committedDuration { get; set; }
        [Display(Name = "Billable")]
        public bool billable { get; set; }
        [Display(Name = "Gross Margin")]
        public float grossMargin { get; set; }
        [Display(Name = "Net Margin")]
        public float netMargin { get; set; }
        [Display(Name = "Include in Totals")]
        public bool includeInTotals { get; set; }



    }
}