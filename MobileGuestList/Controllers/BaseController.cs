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
        public IBaseInformationProvider Repo
        {
            get
            {
                IBaseInformationProvider repo = this.Session[typeof(IBaseInformationProvider).ToString()] as IBaseInformationProvider;
                if (repo == null)
                {
                    string dbName = this.Session.GetUserDB();
#if (DEBUG)
                    if (dbName == Helper.Local_SQLDBConst)
                    {
                        repo = new LocalInformationProvider();
                    }
                    else
                    {
                        repo = new InformationProvider(dbName);
                    }
#else
                    repo = new InformationProvider(dbName);
#endif
                    this.Session[typeof(IBaseInformationProvider).ToString()] = repo;
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
