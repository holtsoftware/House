using Sannel.House.Server.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Server.Data
{
	[Table("Temperatures")]
	public class Temperature : ITemperature
	{
		[Key]
		public Guid TemperatureId
		{
			get;
			set;
		}

		public Guid DeviceId
		{
			get;
			set;
		}

		IDevice ITemperature.Device
		{
			get
			{
				return this.Device;
			}
		}

		[ForeignKey("DeviceId")]
		public Device Device
		{
			get;
			set;
		}

		public DateTime Date
		{
			get;
			set;
		}

		public double Value
		{
			get;
			set;
		}
	}
}
