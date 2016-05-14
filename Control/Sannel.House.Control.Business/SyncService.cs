using Caliburn.Micro;
using Sannel.House.Control.Data.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Control.Business
{
	public class SyncService : IHandle<HourTickMessage>
	{
		public SyncService(IEventAggregator ea)
		{

		}

		public void Handle(HourTickMessage message)
		{
			Task.Run((System.Action)doSync);
		}

		private void doSync()
		{

		}
	}
}
