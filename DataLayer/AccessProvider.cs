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
        public MobileLoginDetails GetLoginDetails(string code)
        {
            using(var context = new PromosuiteDbContext())
            {
                return context.MobileLoginDetails(code).Select(el => new MobileLoginDetails
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
            }
        }
    }
}
