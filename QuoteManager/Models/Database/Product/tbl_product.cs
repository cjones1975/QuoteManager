using System.ComponentModel.DataAnnotations;

namespace QuoteManager.Models.Database.Product
{
    public class tbl_product
    {
        [Key]
        public int productId { get; set; }
        public int productGroupId { get; set; }
        public string name { get; set; }
        public string controller { get; set; }
    }
}