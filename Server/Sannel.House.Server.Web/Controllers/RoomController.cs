using Sannel.House.Server.Data;
using Sannel.House.Server.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sannel.House.Server.Web.Controllers
{
	[Authorize(Roles="Home")]
	public class RoomController : Controller
	{
		private IDataContext context;
		public RoomController()
		{
			context = new EntityContext();
		}

		public RoomController(IDataContext context)
		{
			this.context = context;
		}

		//
		// GET: /Room/
		public ActionResult Index()
		{
			return View(context.Rooms.OrderBy(i => i.Order));
		}
	}
}