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
	[Table("Rooms")]
	public class Room : IRoom
	{
		[Key]
		public Guid RoomId
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

		private ICollection<ICircuit> circuits;

		public ICollection<ICircuit> Circuits
		{
			get { return circuits ?? (circuits = new List<ICircuit>()); }
		}
	}
}
