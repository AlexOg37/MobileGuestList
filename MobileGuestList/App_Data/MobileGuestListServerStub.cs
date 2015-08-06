using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using MobileGuestList.Models;

namespace MobileGuestList.App_Data
{
	public class MobileGuestListServerStub : IMobileGuestListServer
	{
		public string ValidateUser(string strUsername, string strPassword)
		{
			return "4323243jlkj4l32k4j324lk32j4lk243jlk32j4";
		}
		public ProfileModel GetProfile(string strQuerystring)
		{
			ProfileModel profile = new ProfileModel();

			profile.Username = "Unknown";
			profile.UserID = int.MaxValue;
			profile.SQLDB = "SQLDB";
			profile.CultureFormat = DateTimeFormatInfo.CurrentInfo;
			profile.TimeZone = TimeZone.CurrentTimeZone;
			profile.StationID = int.MaxValue;
			profile.AccessToGuestList = true;

			return profile;
		}
		public IEnumerable<Contest> GetContests()
		{
			List<Contest> list = new List<Contest>();

			list.Add(new Contest { Id = 1, Name = "Contest1" });
			list.Add(new Contest { Id = 2, Name = "Contest2" });
			list.Add(new Contest { Id = 3, Name = "Contest3" });

			return list;
		}
		public IEnumerable<Guest> GetGuests(Contest contest)
		{
			List<Guest> list = new List<Guest>();

			list.Add(new Guest { Id = 1, Name = "Oleg", LastName= "Andriichuk", Birthdate = new DateTime(1970, 7, 7), HomeCity="Kharkov", BusinessCity="Budva", HomePhone="717-34-75", MobilePhone="050-345-75-91", BusinessPhone="717-59-34", FulfillmentDate = DateTime.Now });
			list.Add(new Guest { Id = 2, Name = "Alex", LastName= "Ledok", Birthdate = new DateTime(1980, 8, 8), HomeCity = "Kharkov", BusinessCity = "Budva", HomePhone = "717-75-83", MobilePhone = "095-572-97-77", BusinessPhone = "717-56-21" });
			list.Add(new Guest { Id = 3, Name = "Alex", LastName= "Ogorodnyk", Birthdate = new DateTime(1990, 9, 9), HomeCity = "Kharkov", BusinessCity = "Budva", HomePhone = "717-67-34", MobilePhone = "095-789-34-21", BusinessPhone = "717-45-90" });
         
			return list;
		}
		public void MarkDistributed(Contest contest, DateTime date)
		{
		}
		public void Attend(int iGuestId)
		{
		}
	}
}
