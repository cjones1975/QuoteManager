using System.ComponentModel.DataAnnotations;

namespace QuoteManager.Models.ViewModel.Product
{
    public class ProductFamilyViewModel
    {
        [Key]
        public int productFamilyId { get; set; }
        public string name { get; set; }
    }
}