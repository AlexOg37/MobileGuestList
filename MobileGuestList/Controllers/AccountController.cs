using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.Profile;
using System.Web.WebPages;
using System.Globalization;
using MobileGuestList.Providers;
using Models;
using DataLayer;
using System.ComponentModel.DataAnnotations;

namespace MobileGuestList.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        public class LoginModel
        {
            [Required(ErrorMessage = "Username is required")]
            [Display(Name = "Username")]
            public string Username { get; set; }

            [Required(ErrorMessage = "Password is required")]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [Required(ErrorMessage = "Station is required")]
            [Display(Name = "Station")]
            public string Station { get; set; }

            [Display(Name = "Remember Station")]
            public bool RememberStation { get; set; }
        }

        private AuthenticationProvider _authenticationProvider;

        public AccountController()
        {
            this._authenticationProvider = new AuthenticationProvider();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            var model = new LoginModel();

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string code = _authenticationProvider.GetLoginCodeByUser(model.Username, model.Password);

            if (code.IsEmpty() || code == AccessProvider.NoUserInDbState)
            {
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
                
                return View(model);
            }

            return RedirectToAction("Index", "Home", new RouteValueDictionary(new { v = code }));
        }
    }
}
