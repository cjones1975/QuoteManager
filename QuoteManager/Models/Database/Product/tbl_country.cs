using System.ComponentModel.DataAnnotations;

namespace QuoteManager.Models.Database.Product
{ 
    public class tbl_country
    {
        [Key]
        public string countryId { get; set; }
        public string name { get; set; }
    }
}