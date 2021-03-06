﻿using DataLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web.Profile;
using MobileGuestList.Providers;
using System.Globalization;

namespace MobileGuestList.Providers
{
    public class InformationProvider : IBaseInformationProvider
    {
        IEnumerable<Guest> _guestList;
        IEnumerable<Contest> _contestList;
        int _currentStationId = 0;
        int _currentContestId = 0;
        string _dbName;

        public InformationProvider(string db)
        {
            _dbName = db;
        }

        public IEnumerable<Contest> GetContestsList(int stationId)
        {
            UpdateContestList(stationId);
            return this._contestList;
        }

        public Contest GetContestById(int contestId)
        {
            if (this._contestList == null)
            {
                return null;
            }

            return this._contestList.FirstOrDefault(el => el.Id == contestId) as Contest;
        }

        public IEnumerable<Guest> GetGuestList(int contestId, bool forceUpdate = false)
        {
            UpdateGuestList(contestId, forceUpdate);
            return this._guestList;
        }

        public void MarkDistributed(int contestId)
        {
            MobileLoginDetails mobileLoginDetails = HttpContext.Current.Session[typeof(MobileLoginDetails).ToString()] as MobileLoginDetails;
            string timeZone = mobileLoginDetails.TimeZone.ToString();
            TimeZoneInfo pstZone = TimeZoneInfo.FindSystemTimeZoneById(timeZone);
            var datetime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, pstZone);

            using (var provider = new DataBaseEntityProvider(this._dbName))
            {
                provider.Context.MobileGuestListMarkDistributed(contestId, datetime);
            }
        }

        public void UpdateGuestState(int contWinId, bool mark)
        {
            if (mark)
            {
                MobileLoginDetails mobileLoginDetails = HttpContext.Current.Session[typeof(MobileLoginDetails).ToString()] as MobileLoginDetails;
                string timeZone = mobileLoginDetails.TimeZone.ToString();
                TimeZoneInfo pstZone = TimeZoneInfo.FindSystemTimeZoneById(timeZone);
                var datetime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, pstZone);
                using (var provider = new DataBaseEntityProvider(this._dbName))
                {
                    provider.Context.MobileGuestAttended(contWinId, datetime);
                }
            }
            else
            {
                using (var provider = new DataBaseEntityProvider(this._dbName))
                {
                    provider.Context.MobileGuestRemoveAttended(contWinId);
                }
            }
        }

        public IEnumerable<Station> GetMobileStationList(int userId)
        {
            using (var provider = new DataBaseEntityProvider(this._dbName))
            {
                return provider.Context.MobileStationList(userId).Select(el => new Station()
                {
                    StationCall = el.stationcall,
                    StationId = el.stationid
                }).ToList();
            }
        }

        public MobileLoginDetails ChangeStation(int userId, int stationId)
        {
            using (var provider = new DataBaseEntityProvider(this._dbName))
            {
                return provider.Context.MobileChangeStation(userId, stationId).Select(el => new MobileLoginDetails
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
        }

        void UpdateContestList(int newStationId, bool forceUpdate = false)
        {
            if (this._currentStationId == newStationId && forceUpdate != true)
            {
                return;
            }

            this._currentStationId = newStationId;
            using (var provider = new DataBaseEntityProvider(this._dbName))
            {
                this._contestList = provider.Context.MobileGuestListContests(this._currentStationId).Select(el => new Contest()
                {
                    Id = el.ContestID,
                    Name = el.ContestName,
                    StartDate = el.StartDate
                }).ToList();
            }
        }

        void UpdateGuestList(int newContestId, bool forceUpdate = false)
        {
            if (this._currentContestId == newContestId && forceUpdate != true && this._guestList != null)
            {
                return;
            }

            this._currentContestId = newContestId;
            using (var provider = new DataBaseEntityProvider(this._dbName))
            {
                this._guestList = provider.Context.MobileGuestListPeople(this._currentContestId).Select(el => new Guest()
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
        }
    }
}