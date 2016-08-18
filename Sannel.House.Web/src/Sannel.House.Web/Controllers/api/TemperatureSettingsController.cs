﻿using System;
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

		public TemperatureSettingsController(IDataContext context)
		{
			this.context = context;
		}

		public IEnumerable<TemperatureSetting> Get()
		{
			return Get(DateTime.Now);
		}

		[HttpGet("{dt}")]
		public IEnumerable<TemperatureSetting> Get(DateTime dt)
		{
			var daysOfWeek = (from f in context.TemperatureSettings
							  where f.DayOfWeek != null
							  && f.Month == null
							  && f.Start == null
							  && f.End == null
							  select f);

			return daysOfWeek;
		}

		private TemperatureSetting getDefault()
		{
			var first = (from f in context.TemperatureSettings
						 where f.DayOfWeek == null
							 && f.Start == null
							 && f.End == null
						 orderby f.DateModified descending
						 select f).FirstOrDefault();
			if (first == null)
			{
				first = new TemperatureSetting();
				first.HeatTemperatureC = 15.6;
				first.CoolTemperatureC = 29.5;
				context.TemperatureSettings.Add(first);
				context.SaveChanges();
			}

			return first;
		}

		// GET: api/values
		/// <summary>
		/// Gets the TemperatureSettings that would be applyed from today -1, today, today +1, today +2
		/// </summary>
		/// <returns></returns>
		//[HttpGet]
		//public IEnumerable<TemperatureSetting> Get(DateTime now)
		//{
		//	var resultDefaults = (from f in context.TemperatureSettings
		//						  where f.DayOfWeek == null
		//							  && f.LongStartDate == null
		//							  && f.LongEndDate == null
		//						  orderby f.DateModified descending
		//						  select f).Take(1);
		//	if(resultDefaults.Count() == 0)
		//	{
		//		var first = new TemperatureSetting();
		//		first.HeatTemperatureC = 15.6;
		//		first.CoolTemperatureC = 29.5;
		//		context.TemperatureSettings.Add(first);
		//		context.SaveChanges();

		//		resultDefaults = (from f in context.TemperatureSettings
		//						  where f.DayOfWeek == null
		//							  && f.LongStartDate == null
		//							  && f.LongEndDate == null
		//						  orderby f.DateModified descending
		//						  select f).Take(1);
		//	}

		//	var yesterday = now.AddDays(-1);
		//	var tomorrow = now.AddDays(1);
		//	var twoDays = now.AddDays(2);
		//	var resultsDay = from f in context.TemperatureSettings
		//					 where (f.DayOfWeek == yesterday.DayOfWeek ||
		//						f.DayOfWeek == now.DayOfWeek ||
		//						f.DayOfWeek == tomorrow.DayOfWeek ||
		//						f.DayOfWeek == twoDays.DayOfWeek) &&
		//						f.LongStartDate == null &&
		//						f.LongEndDate == null
		//					 orderby f.DayOfWeek, f.ShortTimeStart
		//					 select f;

		//	return resultDefaults.Union(resultsDay);
		//}

		//// GET api/values/5
		//[HttpGet("{id}")]
		//public string Get(int id)
		//{
		//	return "value";
		//}

		//// POST api/values
		//[HttpPost]
		//public void Post([FromBody]string value)
		//{
		//}

		private void updateTemperatureData(TemperatureSetting setting)
		{
			if (setting.CoolTemperatureC < setting.HeatTemperatureC + 2.222222222)
			{
				setting.CoolTemperatureC = setting.HeatTemperatureC + 2.2222222;
			}
			else if (setting.HeatTemperatureC > setting.CoolTemperatureC - 2.2222222)
			{
				setting.HeatTemperatureC = setting.CoolTemperatureC - 2.2222222;
			}
		}

		// POST api/values
		[HttpPost]
		public long Post([FromBody]TemperatureSetting setting)
		{
			setting.Id = 0;
			setting.DateCreated = DateTime.Now;
			setting.DateModified = DateTime.Now;
			updateTemperatureData(setting);
			context.TemperatureSettings.Add(setting);
			context.SaveChanges();
			return setting.Id;
		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody]TemperatureSetting updatedValue)
		{
			var current = context.TemperatureSettings.FirstOrDefault(i => i.Id == id);
			if (current != null)
			{

				current.HeatTemperatureC = updatedValue.HeatTemperatureC;
				current.CoolTemperatureC = updatedValue.CoolTemperatureC;
				updateTemperatureData(current);
				current.DateModified = DateTime.Now;
				current.DayOfWeek = updatedValue.DayOfWeek;
				current.Month = updatedValue.Month;
				current.End = updatedValue.End;
				current.Start = updatedValue.Start;
				current.IsTimeOnly = updatedValue.IsTimeOnly;
				context.SaveChanges();
			}
		}

		//// DELETE api/values/5
		//[HttpDelete("{id}")]
		//public void Delete(int id)
		//{
		//}
	}
}
