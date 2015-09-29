using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using MobileGuestList.Providers;
using System.Web.Routing;

namespace MobileGuestList.Controllers
{
    public class GuestController : BaseController
    {
        public ActionResult Index()
        {
            Contest currentContest = Helper.GetCurrentContest();

            if (currentContest == null)
            {
                return RedirectToAction("Selection", "Contest", new { withError = true });
            }

            ViewBag.Location = Helper.NavigationTextHeaderMessage;

            HttpSessionStateBase session = HttpContext.Session;
            Contest contest = (Contest)session[Helper.ContestConst];
            
            ViewBag.Contest = contest;
            ViewBag.Guests = this.Repo.GetGuestList(contest.Id, true);

            return View();
        }

        [HttpPost]
        public void UpdateGuestState(int contWinId, bool mark)
        {
            this.Repo.UpdateGuestState(contWinId, mark);
        }
    }
}
