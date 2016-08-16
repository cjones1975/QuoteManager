using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace QuoteManager.Models.ViewModel.Product.CorporateConnect
{
    public class CorporateConnectViewModel
    {
        [Key, HiddenInput(DisplayValue = false)]
        public int corporateConnectId { get; set; }
        [Display(Name = "Existing Site?")]
        public bool existingSite { get; set; }
        [Display(Name = "Router/Connection ID")]
        public string routerName { get; set; }
        [Display(Name = "ISP")]
        public bool isp { get; set; }
        [Display(Name = "ISP Primary Bandwidth")]
        public string ispPrimaryBandwidth { get; set; }
        [Display(Name = "ISP Backup Bandwidth")]
        public string ispBackupBandwidth { get; set; }
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
    }
}