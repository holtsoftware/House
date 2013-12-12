using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Sannel.House.Server.Interfaces;

namespace Sannel.House.Server.Web.Hubs
{
	public class SiteHub : Hub
	{
		public void RoomAdded(IRoom room)
		{
			Clients.All.roomAdded(room);
		}
	}
}