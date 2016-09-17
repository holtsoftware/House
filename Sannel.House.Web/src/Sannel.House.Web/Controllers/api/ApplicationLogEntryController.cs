/* Copyright 2016 Sannel Software, L.L.C.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

	   http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sannel.House.Web.Base.Models;
using Sannel.House.Web.Base.Interfaces;

namespace Sannel.House.Web.Controllers.api
{
	[Route("api/[controller]")]
	public class ApplicationLogEntryController : Controller
	{
		private IDataContext context;
		public ApplicationLogEntryController(IDataContext context)
		{
			this.context = context;
		}

		public IEnumerable<ApplicationLogEntry> Get()
		{
			return context.ApplicationLogEntries.OrderByDescending(i => i.CreatedDate);
		}

		[HttpGet("{id}")]
		public ApplicationLogEntry Get(Guid id)
		{
			return context.ApplicationLogEntries.FirstOrDefault(i => i.Id == id);
		}
	}
}