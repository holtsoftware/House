using Microsoft.AspNet.SignalR;
using Sannel.House.Server.Interfaces;
using Sannel.House.Server.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sannel.House.Server.Web.Extensions
{
	public static class IHubContextExtensions
	{
		public static void RoomAdded(this IHubContext context, RoomModel room)
		{
			if(context != null)
			{
				context.Clients.All.roomAdded(room);
			}
		}
	}
}