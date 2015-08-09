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
        public const string ContestConst = "Contest";
        public static string GetUserDB(this HttpSessionStateBase session)
        {
            MobileLoginDetails mobileLoginDetails = GetCurrentUserDetails();
            return mobileLoginDetails.SQLDB;
        }

        public static MobileLoginDetails GetCurrentUserDetails()
        {
            MobileLoginDetails result = null;
            if (HttpContext.Current.Session != null)
            {
                result = HttpContext.Current.Session[typeof(MobileLoginDetails).ToString()] as MobileLoginDetails;
            }

            return result; 
        }

        public static Contest GetCurrentContest()
        {
            Contest result = null;
            if (HttpContext.Current.Session != null)
            {
                result = HttpContext.Current.Session[ContestConst] as Contest;
            }

            return result;
        }
    }
}