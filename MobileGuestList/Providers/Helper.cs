using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileGuestList.Providers
{
    public static class Helper
    {
        public const string LoginCodeConst = "LoginCode";
        public static string GetUserDB(this HttpSessionStateBase session)
        {
            MobileLoginDetails mobileLoginDetails = GetCurrentUserDetails();
            return mobileLoginDetails.SQLDB;
        }

        public static MobileLoginDetails GetCurrentUserDetails()
        {
            return (MobileLoginDetails)HttpContext.Current.Session[typeof(MobileLoginDetails).ToString()];
        }
    }
}