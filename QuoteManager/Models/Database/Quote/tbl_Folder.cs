using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuoteManager.Models.Database.Quote
{
    public class tbl_Folder
    {
        public int folderId { get; set; }
        public int userId { get; set; }
        public string name { get; set; }
    }
}