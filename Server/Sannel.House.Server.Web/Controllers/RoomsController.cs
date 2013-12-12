using Sannel.House.Server.Data;
using Sannel.House.Server.Interfaces;
using Sannel.House.Server.Web.Hubs;
using Sannel.House.Server.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GlobalHost = Microsoft.AspNet.SignalR.GlobalHost;
using Sannel.House.Server.Web.Extensions;

namespace Sannel.House.Server.Web.Controllers
{
	[Authorize(Roles="Home")]
	public class RoomsController : ApiController
	{
		private IDataContext context;

		public RoomsController()
		{
			context = new EntityContext();
		}

		[HttpPost]
		public void AddRoom([FromBody]RoomModel model)
		{
			if(ModelState.IsValid)
			{
				model.RoomId = Guid.NewGuid();
				model.Order = context.Rooms.Max(i => i.Order) + 1;
				context.AddRoom(model);
				context.SaveChanges();
				var hubContext = GlobalHost.ConnectionManager.GetHubContext<SiteHub>();
				model.CircitCount = 0;
				hubContext.RoomAdded(model);
			}
		}

		public IEnumerable<RoomModel> GetRooms()
		{
			return from r in context.Rooms
				   orderby r.Order
				   select new RoomModel
				   {
					   RoomId = r.RoomId,
					   Name = r.Name,
					   Description = r.Description,
					   Order = r.Order,
					   Color = r.Color,
					   CircitCount = context.Circuits.Count(i => i.RoomId == r.RoomId)
				   };
		}
	}
}