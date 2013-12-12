using Sannel.House.Server.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Server.Mocks
{
	public class MockRoom : IRoom
	{
		public Guid RoomId
		{
			get;
			set;
		}

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

		private List<ICircuit> circuits = new List<ICircuit>();

		public ICollection<ICircuit> Circuits
		{
			get { return circuits; }
		}
	}
}
