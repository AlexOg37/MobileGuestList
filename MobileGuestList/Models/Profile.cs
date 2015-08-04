using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Security;
using System.Globalization;

namespace MobileGuestList.Models
{
	public class ProfileModel
	{
		public string Username { get; set; }
		public int UserID { get; set; }
		public string SQLDB { get; set; }
		public DateTimeFormatInfo CultureFormat { get; set; }
		public TimeZone TimeZone { get; set; }
		public int StationID { get; set; }
		public bool AccessToGuestList { get; set; }
	}
}