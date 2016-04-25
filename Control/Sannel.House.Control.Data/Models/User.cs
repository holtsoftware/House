using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Control.Data.Models
{
	public class User
	{
		[Key]
		public Guid Id
		{
			get;
			set;
		}

		public String Username { get; set; }
		public String Password { get; set; }

		public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

		public bool IsEnabled { get; set; }
	}
}
