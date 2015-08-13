using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Profile;
using MobileGuestList.App_Data;
using MobileGuestList.Providers;
using Models;
using System.ComponentModel.DataAnnotations;


namespace MobileGuestList.Controllers
{
	public class HomeController : BaseController
	{
		public ActionResult Help()
		{
			ViewBag.Location = "Help";

			return View();
		}
        public ActionResult Navigation()
        {
            ViewBag.Username = Helper.GetCurrentUserDetails().UserName;
            ViewBag.StationCall = Helper.GetCurrentUserDetails().StationCall;
            ViewBag.StationID = Helper.GetCurrentUserDetails().StationID;    
        
            int userId = Helper.GetCurrentUserDetails().UserID;
            
            ViewBag.Stations = this.Repo.GetMobileStationList(userId);

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

            return RedirectToAction("Selection", "Contest");
        }

        public ActionResult SignOut()
        {
            HttpContext.Session[Helper.LoginCodeConst] = null;

            return RedirectToAction("Login", "Account");
        }
	}
}
