using System.ComponentModel.DataAnnotations;

namespace QuoteManager.Models.Database.Product
{
    public class tbl_productgroup
    {
        [Key]
        public int productGroupId { get; set; }
        public int productFamilyId { get; set; }
        public string name { get; set; }
    }
}