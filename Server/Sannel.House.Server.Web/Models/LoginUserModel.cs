using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sannel.House.Server.Web.Models
{
	public class LoginUserModel
	{
		[Required]
		[StringLength(256, MinimumLength = 3)]
		public string UserName
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
	}
}