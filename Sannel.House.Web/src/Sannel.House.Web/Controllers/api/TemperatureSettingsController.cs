using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sannel.House.Web.Base.Models;
using Sannel.House.Web.Base.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Sannel.House.Web.Controllers.api
{
	[Route("api/[controller]")]
	public class TemperatureSettingsController : Controller
	{
		private IDataContext context;
		//public DevicesController()
		//{
		//}
		public TemperatureSettingsController(IDataContext context)
		{
			this.context = context;
		}
		// GET: api/values
		[HttpGet]
		public IEnumerable<TemperatureSetting> Get()
		{
			var resultDefaults = from f in context.TemperatureSettings
						  where f.DayOfWeek == null
							  && f.LongStartDate == null
							  && f.LongEndDate == null
						  select f;

			var now = DateTime.Now;
			var yesterday = now.AddDays(-1);
			var tomorrow = now.AddDays(1);
			var resultsDay = from f in context.TemperatureSettings
							 where (f.DayOfWeek == yesterday.DayOfWeek ||
								f.DayOfWeek == now.DayOfWeek ||
								f.DayOfWeek == tomorrow.DayOfWeek) &&
								f.LongStartDate == null &&
								f.LongEndDate == null
							 select f;

			return resultDefaults.Union(resultsDay);
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/values
		[HttpPost]
		public void Post([FromBody]string value)
		{
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
