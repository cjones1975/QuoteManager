using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuoteManager.Models.ViewModel.Quote
{
    public class QuoteAddEditViewModel
    {
        [Key]
        public int quoteId { get; set; }
        public int userId { get; set; }
        public int folderId { get; set; }
        [Display(Name = "Customer")]
        public Nullable<int> customerId { get; set; }
        [Display(Name = "Geo")]
        public string geo { get; set; }
        [Required(ErrorMessage = "A quote name is required.")]
        [Display(Name = "Quote Name")]
        public string name { get; set; }
        [Display(Name = "Contact First Name")]
        public string contactFirstName { get; set; }
        [Display(Name = "Contact Last Name")]
        public string contactLastName { get; set; }
        [Display(Name = "Created Date")]
        public DateTime createdDate { get; set; }
        [Display(Name = "Modified Date")]
        public DateTime modifiedDate { get; set; }
        [Display(Name = "Price Effective Date")]
        public DateTime priceEffectiveDate { get; set; }
        [Display(Name = "Validity Date")]
        public DateTime validityDate { get; set; }
        [Display(Name = "Quote Firm?")]
        public bool firmQuote { get; set; }
        [Display(Name = "Status")]
        public int quoteStatusId { get; set; }
        [Display(Name = "QuoteType")]
        public int quoteTypeId { get; set; }
        [Display(Name = "C2C Id")]
        public string c2cId { get; set; }
        [Display(Name = "Currency")]
        public int currencyId { get; set; }
        [Display(Name = "Quote Cancelled?")]
        public bool quoteCancelled { get; set; }
        [Display(Name = "Owner")]
        public string owner { get; set; }

        public class Customer
        {
            [Key]
            public int customerId { get; set; }
            public string alphaCode { get; set; }
            public string name { get; set; }
        }

        public class Currency
        {
            [Key]
            public int currencyId { get; set; }
            public string currency { get; set; }
        }

        public class QuoteStatus
        {
            [Key]
            public int quoteStatusId { get; set; }
            public string name { get; set; }
        }

        public class QuoteType
        {
            [Key]
            public int quoteTypeId { get; set; }
            public string name { get; set; }
        }

        public List<Customer> Customers { get; set; }
        public List<Currency> Currencies { get; set; }
        public List<QuoteStatus> QuoteStatuses { get; set; }
        public List<QuoteType> QuoteTypes {get;set;}
    }
}