using System;
using System.ComponentModel.DataAnnotations;

namespace QuoteManager.Models.ViewModel.Error
{
    public class ErrorReportViewModel
    {
        public string controllerName { get; set; }
        public string actionName { get; set; }
        public string exceptionType { get; set; }
        public string exceptionMessage { get; set; }
        public DateTime time { get; set; }
        [Required]
        public string userComment { get; set; }
        public string message { get; set; }
    }
}