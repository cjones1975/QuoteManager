using System.ComponentModel.DataAnnotations;

namespace QuoteManager.Models.Database.Quote
{
    public class tbl_quotestatus
    {
        [Key]
        public int quoteStatusId { get; set; }
        public string name { get; set; }
    }
}