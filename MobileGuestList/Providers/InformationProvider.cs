using DataLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileGuestList.Providers
{
    public class InformationProvider : IDisposable, IBaseInformationProvider
    {
        DataBaseEntityProvider _provider = null;
        IEnumerable<Guest> _guestList;
        IEnumerable<Contest> _contestList;
        int _currentStationId = 0;
        int _currentContestId = 0;
        public InformationProvider(string db)
        {
            this._provider = new DataBaseEntityProvider(db);
        }

        public IEnumerable<Contest> GetContestsList(int stationId)
        {
            UpdateContestList(stationId);
            return this._contestList;
        }

        public Contest GetContestById(int contestId)
        {
            return this._contestList.FirstOrDefault(el => el.Id == contestId) as Contest;
        }

        public IEnumerable<Guest> GetGuestList(int contestId, bool bForceUpdate = false)
        {
            UpdateGuestList(contestId, bForceUpdate);
            return this._guestList;
        }

        public void MarkDistributed(int contestId)
        {
            this._provider.Context.MobileGuestListMarkDistributed(contestId, DateTime.Now);
        }

        public void UpdateGuestState(int contWinId, bool bMark)
        {
            if (bMark)
            {
                this._provider.Context.MobileGuestAttended(contWinId, DateTime.Now);
            }
            else
            {
                this._provider.Context.MobileGuestRemoveAttended(contWinId);
            }
        }

        public IEnumerable<Station> GetMobileStationList(int useerId)
        {
            return this._provider.Context.MobileStationList(useerId).Select(el => new Station()
            {
                StationCall = el.stationcall,
                StationId = el.stationid
            }).ToList();
        }

        public MobileLoginDetails ChangeStation(int userId, int stationId)
        {
            return this._provider.Context.MobileChangeStation(userId, stationId).Select(el => new MobileLoginDetails
            {
                UserName = el.UserName,
                UserID = el.UserID,
                SQLDB = el.SQLDB,
                CultureFormat = el.CultureFormat,
                TimeZone = el.TimeZone,
                StationID = el.StationID,
                AccessToGuestList = el.AccessToGuestList,
            }).FirstOrDefault();
        }

        void UpdateContestList(int newStationId, bool bForceUpdate = false)
        {
            if (this._currentStationId == newStationId && bForceUpdate != true)
            {
                return;
            }

            this._currentStationId = newStationId;
            this._contestList = this._provider.Context.MobileGuestListContests(this._currentStationId).Select(el => new Contest()
            {
                Id = el.ContestID,
                Name = el.ContestName,
                StartDate = el.StartDate
            }).ToList();
        }

        void UpdateGuestList(int newContestId, bool bForceUpdate = false)
        {
            if (this._currentContestId == newContestId && bForceUpdate != true && this._guestList != null)
            {
                return;
            }

            this._currentContestId = newContestId;
            this._guestList = this._provider.Context.MobileGuestListPeople(this._currentContestId).Select(el => new Guest()
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
                FulfillmentDate = el.FulfillmentDate,
                Attended = el.attended
            }).ToList();
        }

        public void Dispose()
        {
           // this._provider.Context.Dispose();
        }
    }
}