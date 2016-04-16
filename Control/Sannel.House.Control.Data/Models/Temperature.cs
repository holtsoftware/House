using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Control.Data.Models
{
	public class Temperature
	{
		public long Id
		{
			get; set;
		}

		[Required]
		public float Value { get; set; }
	}
}
