using System.ComponentModel.DataAnnotations;

namespace QuoteManager.Models.Database.Quote
{
    public class tbl_quotefolder
    {
        [Key]
        public int folderId { get; set; }
        public int userId { get; set; }
        public string name { get; set; }
    }
}