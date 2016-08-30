using System.ComponentModel.DataAnnotations;

namespace QuoteManager.Models.Database.Product
{
    public class tbl_assignedproducts
    {
        [Key]
        public int assignedProductId { get; set; }
        public int quoteId { get; set; }
        public int productId { get; set; }
        public float? discount { get; set; } 
        public string scenarioId { get; set; }
        
    }
}