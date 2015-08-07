using System;
using System.Collections.Generic;
using Models;

namespace MobileGuestList.App_Data
{
	public interface IMobileGuestListServer
	{
		string ValidateUser(string strUsername, string strPassword);
        MobileLoginDetails GetProfile(string strQuerystring);
		IEnumerable<Contest> GetContests();
		IEnumerable<Guest> GetGuests(Contest contest);
		void MarkDistributed(Contest contest, DateTime date);
		void Attend(int iGuestId);
	}
}
