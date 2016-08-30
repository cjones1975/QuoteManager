using System.ComponentModel.DataAnnotations;

namespace QuoteManager.Models.ViewModel.Product
{
    public class ServiceNet1ViewModel
    {
        [Key]
        public int serviceNet1Id { get; set; }
        public string name { get; set; }
    }
}