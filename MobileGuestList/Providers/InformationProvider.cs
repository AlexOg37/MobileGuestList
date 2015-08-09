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
        DataBaseEntityProvider _provider = null;
        IEnumerable<Guest> _guestList;
        IEnumerable<Contest> _contestList;
        int _currentStationId = 0;
        int _currentContestId = 0;
        public InformationProvider(string db)
        {
            _provider = new DataBaseEntityProvider(db);
        }

        public IEnumerable<Contest> GetContestsList(int stationId)
        {
            UpdateContestList(stationId);
            return this._contestList;
        }

        public Contest GetContestById(int contestId)
        {
            return this._contestList.Where(el => el.Id == contestId).FirstOrDefault() as Contest;
        }

        public IEnumerable<Guest> GetGuestList(int contestId)
        {
            UpdateGuestList(contestId);
            return this._guestList;
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

        void UpdateContestList(int newStationId, bool bForceUpdate = false)
        {
            if (this._currentStationId == newStationId && bForceUpdate != true)
            {
                return;
            }

            this._currentStationId = newStationId;
            this._contestList = _provider.Context.MobileGuestListContests(this._currentStationId).Select(el => new Contest()
            {
                Id = el.ContestID,
                Name = el.ContestName,
                StartDate = el.StartDate
            }).AsEnumerable();
        }

        void UpdateGuestList(int newContestId, bool bForceUpdate = false)
        {
            if (this._currentContestId == newContestId && bForceUpdate != true)
            {
                return;
            }

            this._currentContestId = newContestId;
            this._guestList = _provider.Context.MobileGuestListPeople(this._currentContestId).Select(el => new Guest()
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
        }
    }
}