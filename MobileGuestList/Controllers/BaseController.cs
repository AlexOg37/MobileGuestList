using MobileGuestList.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
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
                    repo = new InformationProvider(dbName);
                    this.Session[typeof(IBaseInformationProvider).ToString()] = repo;
                }

                return repo;
            }
        }

        public RedirectResult RedirectToLogin()
        {
            return Redirect(WebConfigurationManager.AppSettings["loginUrl"]);
        }

    }
}
