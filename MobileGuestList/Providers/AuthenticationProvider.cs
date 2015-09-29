using DataLayer;
using Models;
using System;

namespace MobileGuestList.Providers
{
    public class AuthenticationProvider
    {
        AccessProvider _provider;

        public AuthenticationProvider()
        {
            this._provider = new AccessProvider();
        }

        public string GetLoginCodeByUser(string strUsername, string strPassword)
        {
            return this._provider.GetLoginCode(strUsername, strPassword);
        }

        public MobileLoginDetails GetProfile(string strQuerystring)
        {
            MobileLoginDetails logDetails = null;
            try
            {
                logDetails = this._provider.GetLoginDetails(strQuerystring);
            }
            catch (Exception) { }

            return logDetails;
        }
    }
}
