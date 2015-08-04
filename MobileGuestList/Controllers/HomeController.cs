using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileGuestList.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Help()
		{
			ViewBag.Location = "Help";

			return View();
		}
	}
}
