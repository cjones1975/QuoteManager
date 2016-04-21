using System.ComponentModel.DataAnnotations;

namespace QuoteManager.Models.Database.Quote
{
    public class tbl_customer
    {
        [Key]
        public int customerId { get; set; }
        public string alphacode { get; set; }
        public string name { get; set; }
    }
}