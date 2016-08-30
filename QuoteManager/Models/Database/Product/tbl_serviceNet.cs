using System.ComponentModel.DataAnnotations;

namespace QuoteManager.Models.Database.Product
{
    public class tbl_serviceNet
    {
        [Key]
        public int serviceNetId { get; set; }
        public string name { get; set; }
        public float cost { get; set; }
        public float price { get; set; }
    }
}