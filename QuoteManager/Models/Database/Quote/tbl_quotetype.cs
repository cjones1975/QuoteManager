using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuoteManager.Models.Database.Quote
{
    public class tbl_quotetype
    {
        [Key]
        public int quoteTypeId { get; set; }
        public string name { get; set; }
    }
}