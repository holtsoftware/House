using Sannel.House.Server.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sannel.House.Server.Web.Models
{
	public class RoomModel : IRoom
	{
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

		[StringLength(25)]
		public String Color
		{
			get;
			set;
		}

		public int Order
		{
			get;
			set;
		}

		public int CircitCount
		{
			get;
			set;
		}

		public ICollection<ICircuit> Circuits
		{
			get { return null; }
		}
	}
}