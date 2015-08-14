using DataLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileGuestList.Providers
{
    public class LocalInformationProvider : IBaseInformationProvider
    {
        List<Guest> _guestList;
        List<Contest> _contestList;
        List<Station> _stationList;

        public LocalInformationProvider()
        {
            this._contestList = new List<Contest>();

            this._contestList.Add(new Contest { Id = 1, Name = "Contest1", StartDate = DateTime.Now });
            this._contestList.Add(new Contest { Id = 2, Name = "Contest2", StartDate = DateTime.Now });
            this._contestList.Add(new Contest { Id = 3, Name = "Contest3", StartDate = DateTime.Now });

            this._guestList = new List<Guest>();

            this._guestList.Add(new Guest
            {
                ContWinID = 1,
                Id = 1,
                Name = "Jhon",
                LastName = "Snow",
                Birthdate = new DateTime(1970, 7, 7),
                HomeCity = "Winterfell",
                BusinessCity = "The Wall",
                HomePhone = "",
                MobilePhone = "",
                BusinessPhone = "",
                FulfillmentDate = null,
                Attended = null
            });
            this._guestList.Add(new Guest
            {
                ContWinID = 2,
                Id = 2,
                Name = "Luke",
                LastName = "Skywalker",
                Birthdate = new DateTime(4970, 7, 7),
                HomeCity = "",
                BusinessCity = "",
                HomePhone = "",
                MobilePhone = "",
                BusinessPhone = "",
                FulfillmentDate = null,
                Attended = null
            });
            this._guestList.Add(new Guest
            {
                ContWinID = 3,
                Id = 3,
                Name = "Ivan",
                LastName = "Ivanov",
                Birthdate = null,
                HomeCity = "HomeCity",
                BusinessCity = "BusinessCity",
                HomePhone = "",
                MobilePhone = "050-345-75-91",
                BusinessPhone = "717-59-34",
                FulfillmentDate = null,
                Attended = null
            });
            this._guestList.Add(new Guest
            {
                ContWinID = 4,
                Id = 4,
                Name = "Petr",
                LastName = "Petrov",
                Birthdate = null,
                HomeCity = "HomeCity",
                BusinessCity = "BusinessCity",
                HomePhone = "",
                MobilePhone = "050-345-75-91",
                BusinessPhone = "717-59-34",
                FulfillmentDate = null,
                Attended = null
            });
            this._guestList.Add(new Guest
            {
                ContWinID = 5,
                Id = 5,
                Name = "Vasyl",
                LastName = "Vasyliev",
                Birthdate = null,
                HomeCity = "HomeCity",
                BusinessCity = "BusinessCity",
                HomePhone = "",
                MobilePhone = "050-345-75-91",
                BusinessPhone = "717-59-34",
                FulfillmentDate = null,
                Attended = null
            });

            this._stationList = new List<Station>();

            this._stationList.Add(new Station { StationId = 1, StationCall = "Buzz FM" });
            this._stationList.Add(new Station { StationId = 2, StationCall = "Radio Rocks" });
            this._stationList.Add(new Station { StationId = 3, StationCall = "Freedom FM" });
            this._stationList.Add(new Station { StationId = 4, StationCall = "Classic FM" });
            this._stationList.Add(new Station { StationId = 5, StationCall = "Kiss FM" });
        }

        public IEnumerable<Contest> GetContestsList(int stationId)
        {
            return this._contestList;
        }

        public Contest GetContestById(int contestId)
        {
            return this._contestList.FirstOrDefault(el => el.Id == contestId) as Contest;
        }

        public IEnumerable<Guest> GetGuestList(int contestId, bool bForceUpdate = false)
        {
            return this._guestList;
        }

        public void MarkDistributed(int contestId)
        {
        }

        public void UpdateGuestState(int contWinId, bool bMark)
        {
        }

        public IEnumerable<Station> GetMobileStationList(int useerId)
        {
            return this._stationList;
        }

        public MobileLoginDetails ChangeStation(int userId, int stationId)
        {
            MobileLoginDetails loginDetails = Helper.GetCurrentUserDetails();
            Station station = this._stationList.FirstOrDefault(el => el.StationId == stationId) as Station;
            if (station != null)
            {
                loginDetails.StationID = station.StationId;
                loginDetails.StationCall = station.StationCall;
            }

            return loginDetails;
        }
    }
}