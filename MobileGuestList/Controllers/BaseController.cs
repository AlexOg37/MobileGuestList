using MobileGuestList.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileGuestList.Controllers
{
    [AutentificationValidation]
    public class BaseController : Controller
    {
        private InformationProvider _repo;
        public InformationProvider Repo
        {
            get
            {
                if (this._repo == null)
                {
                    string dbName = this.Session.GetUserDB();
                    dbName = string.Empty;
                    this._repo = new InformationProvider(dbName);
                }
                return this._repo;
            }
        }

        public BaseController()
        {
            
        }

        public RedirectToRouteResult RedirectToLogin()
        {
            return RedirectToAction("Login", "Account");
        }

    }
}
