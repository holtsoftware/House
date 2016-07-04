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
		public Device Get(int id)
		{
			return context.Devices.FirstOrDefault(i => i.Id == id);
		}

		// POST api/values
		[HttpPost]
		public async Task<int> Post([FromBody]Device value)
		{
			if (ModelState.IsValid)
			{
				value.Id = default(int);
				value.DateCreated = DateTime.Now;
				value.DisplayOrder = context.Devices.Count() + 1;
				context.Devices.Add(value);
				await context.SaveChangesAsync();

				return value.Id;
			}
			else
			{
				throw new Exception("Model is not valid");
			}
		}

		// PUT api/values/5
		[HttpPut()]
		public async Task Put([FromBody]Device updated)
		{
			if (ModelState.IsValid)
			{
				var device = context.Devices.FirstOrDefault(i => i.Id == updated.Id);
				if(device == null)
				{
					throw new KeyNotFoundException($"The Id {updated.Id} was not found");
				}
				device.Name = updated.Name;
				device.Description = updated.Description;
				device.DisplayOrder = updated.DisplayOrder;
				await context.SaveChangesAsync();
			}
			else
			{
				throw new Exception("Model is not valid");
			}
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public async Task Delete(int id)
		{
			var d = context.Devices.FirstOrDefault(i => i.Id == id);
			if(d == null)
			{
				throw new KeyNotFoundException($"The id {id} was not found");
			}
			context.Devices.Remove(context.Devices.FirstOrDefault(i => i.Id == id));
			await context.SaveChangesAsync();
		}
	}
}
