using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Profile;
using MobileGuestList.Providers;
using Models;
using System.ComponentModel.DataAnnotations;
using System.Globalization;


namespace MobileGuestList.Controllers
{
	public class HomeController : BaseController
	{
        private const string ValidationKeyError = "The validation key is wrong or there is no connetion with database!";
        private AuthenticationProvider _authenticationProvider;

        public HomeController()
        {
            this._authenticationProvider = new AuthenticationProvider();
        }

        public ActionResult Index(string v)
        {
            HttpContext.Session[Helper.LoginCodeConst] = v;

            MobileLoginDetails mobileLoginDetails = _authenticationProvider.GetProfile(v);

            if (mobileLoginDetails == null)
            {
#if (LOCALDB)
                mobileLoginDetails = new MobileLoginDetails()
                {
                    UserName = "LocalName",
                    UserID = 1,
                    SQLDB = Helper.Local_SQLDBConst,
                    CultureFormat = DateTimeFormatInfo.CurrentInfo.ToString(),
                    TimeZone = TimeZone.CurrentTimeZone.ToString(),
                    StationID = 1,
                    AccessToGuestList = true
                };
#else
                ModelState.AddModelError("", ValidationKeyError);
                return View();
#endif
            }

            HttpContext.Session[mobileLoginDetails.GetType().ToString()] = mobileLoginDetails;

            return RedirectToAction("Selection", "Contest");
        }

        public ActionResult Help()
		{
			ViewBag.Location = "Help";

			return View();
		}
        [HttpPost]
        public ActionResult ChangeStation(int stationId)
        {
            int userId = Helper.GetCurrentUserDetails().UserID;
        
            this.Repo.ChangeStation(userId, stationId);
            MobileLoginDetails mobileLoginDetails = HttpContext.Session[typeof(MobileLoginDetails).ToString()] as MobileLoginDetails;

            mobileLoginDetails.StationID = stationId;

            HttpContext.Session[mobileLoginDetails.GetType().ToString()] = mobileLoginDetails;

            var resultList = this.Repo.GetContestsList(stationId).ToList();

            return Json(resultList);
        }

        public ActionResult LogOut()
        {
            HttpContext.Session[Helper.LoginCodeConst] = null;

            return RedirectToLogin();
        }
	}
}
