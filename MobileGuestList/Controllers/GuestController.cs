using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileGuestList.App_Data;
using Models;

namespace MobileGuestList.Controllers
{
	public class GuestController : BaseController
	{
		public ActionResult Index()
		{
			ViewBag.Location = "Listener Database > Guest Lists";

			HttpSessionStateBase session = HttpContext.Session;
			Contest contest = (Contest)session["Contest"];
			ViewBag.Contest = contest;

			HttpApplicationStateBase application = HttpContext.Application;
			IMobileGuestListServer server = (IMobileGuestListServer)application["IMobileGuestListServer"];
			ViewBag.Guests = server.GetGuests(contest);

			return View();
		}

	}
}
