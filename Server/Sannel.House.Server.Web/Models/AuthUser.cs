using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sannel.House.Server.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Sannel.House.Server.Web.Models
{
	public class AuthUser
	{
		[Required]
		[StringLength(256, MinimumLength = 3)]
		public string UserName
		{
			get;
			set;
		}

		[Required]
		[StringLength(256, MinimumLength = 3)]
		public String DisplayName
		{
			get;
			set;
		}

		[Required]
		[RegularExpression("\\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,6}\\b")]
		public String EmailAddress
		{
			get;
			set;
		}

		[Required]
		public String Password
		{
			get;
			set;
		}

		public bool IsAllowed
		{
			get;
			set;
		}

		public bool IsAdmin
		{
			get;
			set;
		}
	}
}