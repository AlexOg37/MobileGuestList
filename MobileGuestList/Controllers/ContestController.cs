using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Profile;
using MobileGuestList.App_Data;
using MobileGuestList.Providers;
using Models;

namespace MobileGuestList.Controllers
{
	public class ContestController : BaseController
	{
		public ActionResult Selection()
		{
            ViewBag.Location = "Listener Database > Guest Lists";

            //HttpApplicationStateBase application = HttpContext.Application;
            //IMobileGuestListServer server = (IMobileGuestListServer)application["IMobileGuestListServer"];
            //ViewBag.Contests = server.GetContests();

            if (Helper.GetCurrentUserDetails() == null)
                RedirectToAction("Login", "Account");

            int stationId = Helper.GetCurrentUserDetails().StationID;
            ViewBag.Contests = this.Repo.GetContestsList(stationId);

            return View();
		}

		[HttpPost]
		public ActionResult Selection(Contest contest)
		{
			HttpSessionStateBase session = HttpContext.Session;
			session["Contest"] = contest;

            //HttpApplicationStateBase application = HttpContext.Application;
            //IMobileGuestListServer server = (IMobileGuestListServer)application["IMobileGuestListServer"];
            //IEnumerable<Guest> guests = server.GetGuests(contest);

            IEnumerable<Guest> guests = this.Repo.GetGuestList(contest.Id);

			bool boDistributed = true;
			foreach (Guest guest in guests)
			{
				if (guest.FulfillmentDate == null)
				{
					boDistributed = false;
					break;
				}
			}

			if (!boDistributed)
				return RedirectToAction("Distribution");
			return RedirectToAction("Index", "Guest");
		}


		public ActionResult Distribution()
		{
			ViewBag.Location = "Listener Database > Guest Lists";

			HttpSessionStateBase session = HttpContext.Session;
			Contest contest = (Contest)session["Contest"];
			ViewBag.Contest = contest;

			return View();
		}

		public ActionResult Distribute(bool Distribute)
		{
			if (Distribute)
			{
				HttpSessionStateBase session = HttpContext.Session;
				Contest contest = (Contest)session["Contest"];
				ViewBag.Contest = contest;

                //HttpApplicationStateBase application = HttpContext.Application;
                //IMobileGuestListServer server = (IMobileGuestListServer)application["IMobileGuestListServer"];
                //server.MarkDistributed(contest, DateTime.Now);

                int res = this.Repo.MarkDistributed(contest.Id);
			}

			return RedirectToAction("Index", "Guest");
		}
	}
}
