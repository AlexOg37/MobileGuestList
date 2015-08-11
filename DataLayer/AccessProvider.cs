using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class AccessProvider
    {
        public const string NoUserInDbState = "NoUser";

        private PromosuiteDbContext _context = null;

        public AccessProvider()
        {
            this._context = new PromosuiteDbContext();
        }

        public string GetLoginCode(string strUsername, string strPassword)
        {
            var user = this._context.MobileLoggedInUsers.Where(u => u.UserName == strUsername).FirstOrDefault();
            if (user == null)
            {
                return NoUserInDbState;
            }

            return user.VerificationCode;
        }

        public MobileLoginDetails GetLoginDetails(string code)
        {
            var result = this._context.MobileLoginDetails(code).Select(el => new MobileLoginDetails
            {
                UserName = el.UserName,
                UserID = el.UserID,
                SQLDB = el.SQLDB,
                CultureFormat = el.CultureFormat,
                TimeZone = el.TimeZone,
                StationID = el.StationID,
                AccessToGuestList = el.AccessToGuestList,
                StationCall = el.StationCall
            }).FirstOrDefault();

            return result;
        }
    }
}
