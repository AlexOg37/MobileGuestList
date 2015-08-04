using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.Profile;
using System.Globalization;
using MobileGuestList.App_Data;
using MobileGuestList.Models;

namespace MobileGuestList.Controllers
{

	[Authorize]
	public class AccountController : Controller
	{
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
			string returnUrl = "";
			if (ModelState.IsValid)
			{
				if (Membership.ValidateUser(model.Username, model.Password))
				{
					FormsAuthentication.SetAuthCookie(model.Station, model.RememberStation);

					string strLoginCode = "";
					HttpSessionStateBase session = HttpContext.Session;
					session["LoginCode"] = strLoginCode;

					if (Url.IsLocalUrl(returnUrl))
					{
						return Redirect(returnUrl);
					}
					else
					{
						return RedirectToAction("Selection", "Contest");
					}
				}
				else
				{
					ModelState.AddModelError("", "The user name or password provided is incorrect.");
				}
			}

			// If we got this far, something failed, redisplay form
			return View(model);
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
