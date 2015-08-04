using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.Profile;
using System.Configuration;
using System.Data;
using MobileGuestList.App_Data;
using MobileGuestList.Models;

namespace MobileGuestList.Providers
{
	public class MobileGuestListProfileProvider : ProfileProvider
	{
		public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection collection)
		{
			SettingsPropertyValueCollection settings = new SettingsPropertyValueCollection();

			HttpContext HttpContext = HttpContext.Current;
			HttpSessionState session = HttpContext.Session;
			string strLoginCode = (string)session["LoginCode"];
			HttpApplicationState application = HttpContext.Application;
			IMobileGuestListServer server = (IMobileGuestListServer)application["IMobileGuestListServer"];
			ProfileModel profile = server.GetProfile(strLoginCode);

			if (collection != null && collection.Count >= 1 && context != null)
			{
				foreach (SettingsProperty prop in collection)
				{
					SettingsPropertyValue svp = new SettingsPropertyValue(prop);
					switch (prop.Name)
					{
						case "Username":
							svp.PropertyValue = profile.Username;
							break;
						case "UserID":
							svp.PropertyValue = profile.UserID;
							break;
						case "SQLDB":
							svp.PropertyValue = profile.SQLDB;
							break;
						case "CultureFormat":
							svp.PropertyValue = profile.CultureFormat;
							break;
						case "TimeZone":
							svp.PropertyValue = profile.TimeZone;
							break;
						case "StationID":
							svp.PropertyValue = profile.StationID;
							break;
						case "AccessToGuestList":
							svp.PropertyValue = profile.AccessToGuestList;
							break;
						default:
							svp.PropertyValue = null;
							break;
					}
					settings.Add(svp);
				}
			}

			return settings;
		}

		public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection collection)
		{
		}

		public override int DeleteInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
		{
			throw new NotImplementedException();
		}

		public override int DeleteProfiles(string[] usernames)
		{
			throw new NotImplementedException();
		}

		public override int DeleteProfiles(ProfileInfoCollection profiles)
		{
			throw new NotImplementedException();
		}

		public override ProfileInfoCollection FindInactiveProfilesByUserName(ProfileAuthenticationOption authenticationOption, string usernameToMatch, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
		{
			throw new NotImplementedException();
		}

		public override ProfileInfoCollection FindProfilesByUserName(ProfileAuthenticationOption authenticationOption, string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
		{
			throw new NotImplementedException();
		}

		public override ProfileInfoCollection GetAllInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
		{
			throw new NotImplementedException();
		}

		public override ProfileInfoCollection GetAllProfiles(ProfileAuthenticationOption authenticationOption, int pageIndex, int pageSize, out int totalRecords)
		{
			throw new NotImplementedException();
		}

		public override int GetNumberOfInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
		{
			throw new NotImplementedException();
		}

		public override string ApplicationName
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}
	}
}
