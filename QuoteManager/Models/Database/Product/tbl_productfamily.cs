using System.ComponentModel.DataAnnotations;

namespace QuoteManager.Models.Database.Product
{
    public class tbl_productfamily
    {
        [Key]
        public int productFamilyId { get; set; }
        public string name { get; set; }
    }
}