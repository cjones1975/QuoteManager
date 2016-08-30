using System.ComponentModel.DataAnnotations;


namespace QuoteManager.Models.ViewModel.Product
{
    public class ServiceNet3ViewModel
    {
        [Key]
        public int serviceNet3Id { get; set; }
        public string name { get; set; }
    }
}
