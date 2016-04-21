using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace QuoteManager.Models.ViewModel.Quote
{
    public class QuoteViewModel
    {
            public int quoteId { get; set; }
            public int userId { get; set; }
            public int folderId { get; set; }
            public string customer { get; set; }
            [Display(Name = "Geo")]
            public string geo { get; set; }
            [Required(ErrorMessage= "A quote name is required.")]
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
            public string quoteStatus { get; set; }
            [Display(Name = "Type of Quote")]
            public string quoteType { get; set; }
            [Display(Name = "C2C Id")]
            public string c2cId { get; set; }
            [Display(Name = "Currency")]
            public int currencyId { get; set; }
            [Display(Name = "Quote Cancelled?")]
            public bool quoteCancelled { get; set; }
            [Display(Name = "Owner")]
            public string owner { get; set; }
 
            public IEnumerable<SelectListItem> CustomerList { get; set; }
            public IEnumerable<SelectListItem> FolderList { get; set; }
            public IEnumerable<SelectListItem> QuoteTypeList { get; set; }
    }


}