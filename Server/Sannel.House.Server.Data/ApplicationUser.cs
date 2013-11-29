using Microsoft.AspNet.Identity.EntityFramework;
using Sannel.House.Server.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Server.Data
{
	public class ApplicationUser : IdentityUser
	{
		[Required]
		[StringLength(256, MinimumLength=3)]
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
	}
}
