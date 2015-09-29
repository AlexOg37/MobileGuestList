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

        public MobileLoginDetails GetProfile(string verificationCode)
        {
            MobileLoginDetails logDetails = null;
            try
            {
                logDetails = this._provider.GetLoginDetails(verificationCode);
            }
            catch (Exception) { }

            return logDetails;
        }
    }
}
