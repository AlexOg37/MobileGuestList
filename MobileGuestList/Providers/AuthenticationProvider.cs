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
            return this._provider.GetLoginDetails(verificationCode);
        }
    }
}
