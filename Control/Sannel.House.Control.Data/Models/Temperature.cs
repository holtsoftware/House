﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Control.Data.Models
{
	public class Temperature
	{
		[Key]
		public long Id
		{
			get; set;
		}

		public Guid? StoredDeviceId { get; set; }

		public float Value { get; set; }

		public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
	}
}
