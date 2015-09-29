using MobileGuestList.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileGuestList.Providers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AuthenticationValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.ActionDescriptor.ActionName.ToLower() == "index"
                && filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower() == "home")
            {
                return;
            }

            if (filterContext.HttpContext.Session[Helper.LoginCodeConst] == null)
            {
                BaseController controller = filterContext.Controller as BaseController;
                if (controller != null)
                {
                    filterContext.Result = controller.RedirectToLogin();
                }
            }
        }
    }
}