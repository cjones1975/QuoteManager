using System;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace QuoteManager.Models.ViewModel.Account
{
    public class NewUserViewModel
    {
        [Display(Name="Username")]
        public string username { get; set; }
        [Display(Name="Password")]
        public string password { get; set; }
    }
}