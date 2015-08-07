using DataLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileGuestList.Providers
{
    public class InformationProvider
    {
        DataBaseEntityProvider _provider;
        public InformationProvider(string db)
        {
            _provider = new DataBaseEntityProvider(db);
        }
        
        public IEnumerable<Contest> GetContestsList(int stationId)
        {
            IEnumerable<Contest> result = _provider.Context.MobileGuestListContests(stationId).Select(el => new Contest()
            {
                Id = el.ContestID,
                Name = el.ContestName,
                StartDate = el.StartDate
            }).AsEnumerable();
            return result;
        }

        public IEnumerable<Guest> GetGuestList(int contestId)
        {
            IEnumerable<Guest> result = _provider.Context.MobileGuestListPeople(contestId).Select(el => new Guest()
            {
                ContWinID = el.ContWinID,
                Name = el.fname,
                LastName = el.lname,
                HomeCity = el.HCity,
                BusinessCity = el.BCity,
                Birthdate = el.DOB,
                HomePhone = el.HomePhone,
                BusinessPhone = el.WorkPhone,
                MobilePhone = el.MobilePhone,
                FulfillmentDate = el.FulfillmentDate
            }).AsEnumerable();
            return result;
        }

        public int MarkDistributed(int contWinID)
        {
            return _provider.Context.MobileGuestAttended(contWinID, DateTime.Now);
        }

        public void xx3()
        {
            //Context.MobileGuestListMarkDistributed()
        }
        public void xx1()
        {
            //Context.MobileGuestListMarkDistributed()
        }
        public void xx2()
        {
            //Context.MobileGuestListMarkDistributed()
        }
    }
}