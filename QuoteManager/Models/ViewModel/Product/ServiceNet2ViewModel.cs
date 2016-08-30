using System.ComponentModel.DataAnnotations;

namespace QuoteManager.Models.ViewModel.Product
{
    public class ServiceNet2ViewModel
    {
        [Key]
        public int serviceNet2Id { get; set; }
        public string name { get; set; }
    }
}
