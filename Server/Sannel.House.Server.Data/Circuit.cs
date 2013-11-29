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
	[Table("Circuits")]
	public class Circuit : ICircuit
	{
		[Key]
		public Guid CircuitId
		{
			get;
			set;
		}

		public Guid RoomId
		{
			get;
			set;
		}

		IRoom ICircuit.Room
		{
			get { return this.Room; }
		}

		[ForeignKey("RoomId")]
		public Room Room
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

		public string Description
		{
			get;
			set;
		}

		public int Order
		{
			get;
			set;
		}

		private ICollection<IDevice> devices;

		public ICollection<IDevice> Devices
		{
			get { return devices ?? (devices = new List<IDevice>()); }
		}
	}
}
