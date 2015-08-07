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
using MobileGuestList.App_Data;
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
            [Required]
            [Display(Name = "Username")]
            public string Username { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [Required]
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
			return View();
		}

		[AllowAnonymous]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Login(LoginModel model)
		{
            //ToDo: get log in logic to normal state
			//string returnUrl = "";
            
			if (!ModelState.IsValid)
			{
                return View(model);
            }

            string loginCode = _authenticationProvider.GetLoginCodeByUser(model.Username, model.Password);

            if (loginCode.IsEmpty() || loginCode == AccessProvider.NoUserInDbState)
            {
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
                return View(model);
            }

            HttpContext.Session[Helper.LoginCodeConst] = loginCode;

            MobileLoginDetails mobileLoginDetails = _authenticationProvider.GetProfile(loginCode);
            HttpContext.Session[mobileLoginDetails.GetType().ToString()] = mobileLoginDetails;

            return RedirectToAction("Selection", "Contest");

            //if (Membership.ValidateUser(model.Username, model.Password))
            //{
            //    FormsAuthentication.SetAuthCookie(model.Station, model.RememberStation);

            //    string strLoginCode = "";
            //    HttpSessionStateBase session = HttpContext.Session;
            //    session[Helper.LoginCodeConst] = strLoginCode;

            //    if (Url.IsLocalUrl(returnUrl))
            //    {
            //        return Redirect(returnUrl);
            //    }
            //    else
            //    {
            //        return RedirectToAction("Selection", "Contest");
            //    }
            //}
            //else
            //{
            //    ModelState.AddModelError("", "The user name or password provided is incorrect.");
            //}
		}

		public ActionResult LogOff()
		{
			FormsAuthentication.SignOut();

			return RedirectToAction("Login");
		}

		#region Status Codes
		private static string ErrorCodeToString(MembershipCreateStatus createStatus)
		{
			// See http://go.microsoft.com/fwlink/?LinkID=177550 for
			// a full list of status codes.
			switch (createStatus)
			{
				case MembershipCreateStatus.DuplicateUserName:
					return "User name already exists. Please enter a different user name.";

				case MembershipCreateStatus.DuplicateEmail:
					return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

				case MembershipCreateStatus.InvalidPassword:
					return "The password provided is invalid. Please enter a valid password value.";

				case MembershipCreateStatus.InvalidEmail:
					return "The e-mail address provided is invalid. Please check the value and try again.";

				case MembershipCreateStatus.InvalidAnswer:
					return "The password retrieval answer provided is invalid. Please check the value and try again.";

				case MembershipCreateStatus.InvalidQuestion:
					return "The password retrieval question provided is invalid. Please check the value and try again.";

				case MembershipCreateStatus.InvalidUserName:
					return "The user name provided is invalid. Please check the value and try again.";

				case MembershipCreateStatus.ProviderError:
					return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

				case MembershipCreateStatus.UserRejected:
					return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

				default:
					return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
			}
		}
		#endregion
	}
}
