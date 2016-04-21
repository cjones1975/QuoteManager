using System.ComponentModel.DataAnnotations;

namespace QuoteManager.Models.ViewModel.Quote
{
    public class QuoteProductsViewModel
    {
        [Key]
        public int assignedProductId { get; set; }
        public int productId { get; set; }
        [Display(Name = "Product")]
        public string name { get; set; }
        [Display(Name = "OBS quote required")]
        public bool ObsQuoteRequired { get; set; }
        public string controller { get; set; }
    }
}