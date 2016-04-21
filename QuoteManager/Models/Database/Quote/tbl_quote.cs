using System;
using System.ComponentModel.DataAnnotations;

namespace QuoteManager.Models.Database.Quote
{
    public class tbl_quote
    {
        [Key]
        public int quoteId { get; set; }
        public int userId { get; set; }
        public int folderId { get; set; }
        public int customerId { get; set; }
        public string name { get; set; }
        public string contactFirstName { get; set; }
        public string contactLastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime createdDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime modifiedDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime priceEffectiveDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime validityDate { get; set; }
        public bool firmQuote { get; set; }
        public int quoteStatusId { get; set; }
        public int quoteTypeId { get; set; }
        public string c2cId { get; set; }
        public int currencyId { get; set; }
        public bool quoteCancelled { get; set; }
        public string owner { get; set; }


    }
}