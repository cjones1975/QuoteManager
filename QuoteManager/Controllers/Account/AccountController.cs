using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using QuoteManager.Models.ViewModel.Account;

namespace QuoteManager.Controllers.Account
{
    public class AccountController : Controller
    {
        

        // GET: Account
        public ActionResult SignIn()
        {
            return View(new SignInViewModel());
        }

        // POST: Account
        [HttpPost, AllowAnonymous]
        public ActionResult SignIn(SignInViewModel model)
        {
            if (ModelState.IsValid && model != null)
            {
                if (Membership.ValidateUser(model.username, model.password))
                {
                    try
                    {
                        FormsAuthentication.RedirectFromLoginPage(model.username, false);
                    }
                    catch
                    {
                        ModelState.AddModelError("", "Error connecting to the server. Please try again later or contact an administrator.");
                        return View(new SignInViewModel());
                    }
                }
                else
                {
                    if(Membership.GetUser(model.username) != null)
                    {
                        if(Membership.GetUser(model.username).IsLockedOut)
                        {
                            ModelState.AddModelError("", "Due to a number of failed logins, your account has been locked. Please contact an administrator.");
                        }
                    }
                    ModelState.AddModelError("", "The username or password provided is incorrect.");
                
                }
            }
            return View(model);
        }

        public ActionResult NewUser()
        {
            return View();
        }

        // POST
        [HttpPost]
        public ActionResult NewUser(NewUserViewModel user)
        {
            try
            {
                MembershipUser newUser = Membership.CreateUser(user.username, user.password);
               
            }
            catch (MembershipCreateUserException e)
            {

            }
            return View();
        }
            
    }
}