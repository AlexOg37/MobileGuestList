using MobileGuestList.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileGuestList.Controllers
{
    [AuthenticationValidation]
    public class BaseController : Controller
    {
        public InformationProvider Repo
        {
            get
            {
                InformationProvider repo = this.Session[typeof(InformationProvider).ToString()] as InformationProvider;
                if (repo == null)
                {
                    string dbName = this.Session.GetUserDB();
                    repo = new InformationProvider(dbName);
                    this.Session[typeof(InformationProvider).ToString()] = repo;
                }
                return repo;
            }
        }

        public RedirectToRouteResult RedirectToLogin()
        {
            return RedirectToAction("Login", "Account");
        }

    }
}
