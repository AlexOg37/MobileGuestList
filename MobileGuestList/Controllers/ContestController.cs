using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Profile;
using MobileGuestList.Providers;
using Models;
using System.ComponentModel.DataAnnotations;

namespace MobileGuestList.Controllers
{
    public class ContestController : BaseController
    {
        public const string error = "*  You must first select a contest.";
        public class SelectionForm
        {
            [Display(Name = "Id")]
            public int Id { get; set; }

            public string SortByName { get; set; }


        }
        public ActionResult Selection(bool bWithError = false)
        {
            //if (!string.IsNullOrEmpty(error))
            //    ModelState.AddModelError("CustomError", error);
            if (bWithError == true)
                ModelState.AddModelError("keyName", error);

            ViewBag.Location = Helper.NavigationTextHeaderMessage;

            if (Helper.GetCurrentUserDetails() == null)
                RedirectToAction("Login", "Account");

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
                ModelState.AddModelError("keyName", error);


                return View(model);
            }
            contest = this.Repo.GetContestById(contest.Id);
            HttpContext.Session[Helper.ContestConst] = contest;

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

        [HttpPost]
        public ActionResult UpdateContestSelection(int contestId)
        {
            Contest contest = this.Repo.GetContestById(contestId);
            HttpContext.Session[Helper.ContestConst] = contest;

            return Json(new { });
        }

        public ActionResult Distribution()
        {
            ViewBag.Location = Helper.NavigationTextHeaderMessage;

            HttpSessionStateBase session = HttpContext.Session;
            Contest contest = (Contest)session[Helper.ContestConst];
            ViewBag.Contest = contest;

            return View();
        }

        public ActionResult Distribute(bool Distribute)
        {
            if (Distribute)
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
