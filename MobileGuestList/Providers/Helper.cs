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
        public const string NavigationTextHeaderMessage = "Listener Database > Guest Lists";
        public const string Local_SQLDBConst = "Local_SQLDB";
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

        public static string GetUserName()
        {
            return GetCurrentUserDetails() != null ? GetCurrentUserDetails().UserName : string.Empty;
        }
        public static string GetUserStationCall()
        {

            return GetCurrentUserDetails() != null ? GetCurrentUserDetails().StationCall : string.Empty;
        }
        public static IEnumerable<Station> GetStations()
        {
            IEnumerable<Station> result = new List<Station>();
            MobileLoginDetails user = GetCurrentUserDetails();
            if (user != null)
                result = GetRepository().GetMobileStationList(user.UserID).ToList();

            return result;
        }
        public static InformationProvider GetRepository()
        {
            string dbName = GetCurrentUserDetails().SQLDB;
            InformationProvider repo = new InformationProvider(dbName);
            return repo;
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