using DataLayer;
using Models;

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
            return this._provider.GetLoginDetails(strQuerystring);
        }
    }
}
