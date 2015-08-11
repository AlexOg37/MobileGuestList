using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileGuestList.Providers;

namespace MobileGuestList.Controllers
{
	public class HomeController : Controller
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
            return View();
        }
	}
}
