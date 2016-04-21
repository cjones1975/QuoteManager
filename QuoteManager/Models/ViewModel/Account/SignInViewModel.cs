using System;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace QuoteManager.Models.ViewModel.Account
{
    public class SignInViewModel : Controller
    {
        [Required]
        [Display(Name = "Username")]
        [DataType(DataType.EmailAddress, ErrorMessage="Please use a valid email address")]
        public string username {get;set;}

        [Required]
        [Display(Name = "Password")]
        public string password {get;set;}
    }
}