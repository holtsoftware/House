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
	[Table("Devices")]
	public class Device : IDevice
	{
		[Key]
		public Guid DeviceId
		{
			get;
			set;
		}

		public Guid CircuitId
		{
			get;
			set;
		}

		ICircuit IDevice.Circuit
		{
			get
			{
				return this.Circuit;
			}
		}

		[ForeignKey("CircuitId")]
		public Circuit Circuit
		{
			get;
			set;
		}

		[Required]
		[StringLength(256)]
		public string Name
		{
			get;
			set;
		}

		[StringLength(500)]
		public string Key
		{
			get;
			set;
		}

		public string Description
		{
			get;
			set;
		}
	}
}
