using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Profile;
using MobileGuestList.Providers;
using Models;
using System.ComponentModel.DataAnnotations;
using System.Web.UI;
using System.Web.UI.WebControls;
using MobileGuestList.Resources;

namespace MobileGuestList.Controllers
{
    public class ContestController : BaseController
    {
        public ActionResult Selection()
        {
            ViewBag.Location = Resources.Resource.NavigationTextHeaderMessage;

            if (Helper.GetCurrentUserDetails() == null)
            {
                RedirectToLogin();
            }

            int stationId = Helper.GetCurrentUserDetails().StationID;
            ViewBag.Contests = this.Repo.GetContestsList(stationId);
            Contest contest = Helper.GetCurrentContest();

            if (contest != null)
            {
                ViewBag.SelectedContest = contest;
            }

            return View();
        }

        [HttpPost]
        public ActionResult Selection(Contest contest, SelectionForm model)
        {
            if (!ModelState.IsValid)
            {
                int stationId = Helper.GetCurrentUserDetails().StationID;
                
                ViewBag.Contests = this.Repo.GetContestsList(stationId);
                ViewBag.Alert = "<script>Alert();</script>";

                return View(model);
            }

            contest = this.Repo.GetContestById(contest.Id);
            HttpContext.Session[Helper.ContestConst] = contest;

            IEnumerable<Guest> guests = this.Repo.GetGuestList(contest.Id);

            if (guests.Count() == 0)
            {
                int stationId = Helper.GetCurrentUserDetails().StationID;
                
                ViewBag.Contests = this.Repo.GetContestsList(stationId);
                ViewBag.AlertSorry = "<script>AlertSorry();</script>";

                return View(model);
            }

            bool distributed = true;

            foreach (Guest guest in guests)
            {
                if (guest.FulfillmentDate == null)
                {
                    distributed = false;
                    break;
                }
            }

            if (!distributed)
            {
                return RedirectToAction("Distribution");
            }

            return RedirectToAction("Index", "Guest");
        }

        [HttpPost]
        public void UpdateContestSelection(int contestId)
        {
            Contest contest = this.Repo.GetContestById(contestId);
            HttpContext.Session[Helper.ContestConst] = contest;
        }

        public ActionResult Distribution()
        {
            ViewBag.Location = Resources.Resource.NavigationTextHeaderMessage;

            HttpSessionStateBase session = HttpContext.Session;
            Contest contest = (Contest)session[Helper.ContestConst];
            ViewBag.Contest = contest;

            return View();
        }

        public ActionResult Distribute(bool distribute)
        {
            if (distribute)
            {
                HttpSessionStateBase session = HttpContext.Session;
                Contest contest = (Contest)session[Helper.ContestConst];
                ViewBag.Contest = contest;

                this.Repo.MarkDistributed(contest.Id);
            }

            return RedirectToAction("Index", "Guest");
        }
    }
}
