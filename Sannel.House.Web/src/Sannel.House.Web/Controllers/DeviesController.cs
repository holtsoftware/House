using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sannel.House.Web.Base.Models;
using Sannel.House.Web.Base.Interfaces;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Sannel.House.Web.Controllers
{
	[Route("api/devices")]
	[Authorize(Roles = "Admin,Controller")]
	public class DevicesController : Controller
	{
		private IDataContext context;
		//public DevicesController()
		//{
		//}
		public DevicesController(IDataContext context)
		{
			this.context = context;
		}
		// GET: api/values
		[HttpGet]
		public IEnumerable<Device> Get()
		{
			return context.Devices.OrderBy(i => i.DisplayOrder);
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/values
		[HttpPost]
		public void Post([FromBody]Device value)
		{
			value.Id = default(int);
			value.DateCreated = DateTime.Now;
			value.DisplayOrder = context.Devices.Count() + 1;
			context.Devices.Add(value);
			context.SaveChanges();
		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
