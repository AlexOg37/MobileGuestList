using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using Unity.Mvc4;

namespace MobileGuestList.App_Start
{
    public class UnityConfig
    {
        public static void RegisterComponents()
        {
            //var container = new UnityContainer();
            //RegisterTypes(container);

            //DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static void RegisterTypes(IUnityContainer container)
        {

            #region Integration

           // container.RegisterType<IUserControllerProvider, UserControllerProvider>();

            #endregion
        }
    }
}