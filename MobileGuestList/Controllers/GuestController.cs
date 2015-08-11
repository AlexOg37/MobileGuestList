using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileGuestList.App_Data;
using Models;
using MobileGuestList.Providers;

namespace MobileGuestList.Controllers
{
	public class GuestController : BaseController
	{
		public ActionResult Index()
		{
            ViewBag.Location = Helper.NavigationTextHeaderMessage;

			HttpSessionStateBase session = HttpContext.Session;
			Contest contest = (Contest)session[Helper.ContestConst];
			ViewBag.Contest = contest;

            ViewBag.Guests = this.Repo.GetGuestList(contest.Id, true);

			return View();
		}

        [HttpPost]
        public ActionResult UpdateGuestState(int contWinId, bool bMark)
        {
            this.Repo.UpdateGuestState(contWinId, bMark);
            return Json(new {});
        }
	}
}
