using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Helpers;
using System.Security.Cryptography;
using System.Web.WebPages;
using Microsoft.Internal.Web.Utils;
using MobileGuestList.Models;

namespace MobileGuestList.Providers
{
	public class MobileGuestListRoleProvider : RoleProvider
	{
		public override string[] GetRolesForUser(string email)
		{
			string[] role = new string[] { };
// 			using (UserContext _db = new UserContext())
// 			{
// 				try
// 				{
// 					// Получаем пользователя
// 					User user = (from u in _db.Users
// 											 where u.Email == email
// 											 select u).FirstOrDefault();
// 					if (user != null)
// 					{
// 						// получаем роль
// 						Role userRole = _db.Roles.Find(user.RoleId);
// 
// 						if (userRole != null)
// 						{
// 							role = new string[] { userRole.Name };
// 						}
// 					}
// 				}
// 				catch
// 				{
// 					role = new string[] { };
// 				}
// 			}
			return role;
		}
		public override void CreateRole(string roleName)
		{
			throw new NotImplementedException();
		}
		public override bool IsUserInRole(string username, string roleName)
		{
			bool outputResult = true;
			// Находим пользователя
// 			using (UserContext _db = new UserContext())
// 			{
// 				try
// 				{
// 					// Получаем пользователя
// 					User user = (from u in _db.Users
// 											 where u.Email == username
// 											 select u).FirstOrDefault();
// 					if (user != null)
// 					{
// 						// получаем роль
// 						Role userRole = _db.Roles.Find(user.RoleId);
// 
// 						//сравниваем
// 						if (userRole != null && userRole.Name == roleName)
// 						{
// 							outputResult = true;
// 						}
// 					}
// 				}
// 				catch
// 				{
// 					outputResult = false;
// 				}
// 			}
			return outputResult;
		}
		public override void AddUsersToRoles(string[] usernames, string[] roleNames)
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

		public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
		{
			throw new NotImplementedException();
		}

		public override string[] FindUsersInRole(string roleName, string usernameToMatch)
		{
			throw new NotImplementedException();
		}

		public override string[] GetAllRoles()
		{
			throw new NotImplementedException();
		}

		public override string[] GetUsersInRole(string roleName)
		{
			throw new NotImplementedException();
		}

		public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
		{
			throw new NotImplementedException();
		}

		public override bool RoleExists(string roleName)
		{
			throw new NotImplementedException();
		}
	}
}
