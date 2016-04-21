using System.ComponentModel.DataAnnotations;

namespace QuoteManager.Models.Database.Quote
{
    public class tbl_currency
    {
        [Key]
        public int currencyId { get; set; }
        public string currency {get;set;}
    }
}