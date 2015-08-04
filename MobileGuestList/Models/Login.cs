using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Security;

namespace MobileGuestList.Models
{
	public class LoginModel
	{
		[Required]
		[Display(Name = "Username")]
		public string Username { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[Required]
		[Display(Name = "Station")]
		public string Station { get; set; }

		[Display(Name = "Remember Station")]
		public bool RememberStation { get; set; }
	}
}
