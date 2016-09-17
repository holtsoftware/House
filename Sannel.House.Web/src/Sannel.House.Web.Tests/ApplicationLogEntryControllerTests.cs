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
using NUnit.Framework;
using Sannel.House.Web.Base.Interfaces;
using Sannel.House.Web.Base.Models;
using Sannel.House.Web.Controllers.api;
using Sannel.House.Web.Mocks;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sannel.House.Web.Tests
{
	[TestFixture]
	public class ApplicationLogEntryControllerTests : TestBase
	{
		[Test]
		public void GetTest()
		{
			using (IDataContext context = new MockDataContext())
			{
				using (var controller = new ApplicationLogEntryController(context))
				{
					var var1 = new ApplicationLogEntry();
					var var2 = new ApplicationLogEntry();
					var var3 = new ApplicationLogEntry();
					//var1
					var1.Id = Guid.NewGuid();
					var1.DeviceId = 54;
					var1.ApplicationId = "jyy<J3&n4.=";
					var1.Message = "e{*_;>pl00?24/N4@i%f6*!+eyxiCW~-Z.3py)K7}lt,WmV?";
					var1.Exception = "jgI2!cQ.}rnJd?,?LS^Z$*4W([VpDP24CF&s$,/CLPl}";
					var1.CreatedDate = DateTime.Now;
					//var2
					var2.Id = Guid.NewGuid();
					var2.DeviceId = 30;
					var2.ApplicationId = "tS}}(_Eeib[p.,\"fFtZ\\7?/#&L$'_CJP{/?8,";
					var2.Message = "SM%\\yZ6vMN#\\2ba<L-]nxIXk0O'ZlbT\\cl-OBIz{MFo";
					var2.Exception = "KK,O@^x3LQ_a2A|/_K1wzC/A#F&";
					var2.CreatedDate = DateTime.Now;
					//var3
					var3.Id = Guid.NewGuid();
					var3.DeviceId = 43;
					var3.ApplicationId = "}+n0EXBMt%!}DO{Iny=clp6=3s}Q.>.DJ-cmG";
					var3.Message = "WQOCXQFhlo+74Ew,y@6u(|";
					var3.Exception = "w3dOq*[zqWmld`4";
					var3.CreatedDate = DateTime.Now;
					//Fix Order
					var order = DateTime.Now;
					var3.CreatedDate = order;
					var2.CreatedDate = order.AddDays(-1);
					var1.CreatedDate = order.AddDays(-2);
					// Add and save entities
					context.ApplicationLogEntries.Add(var1);
					context.ApplicationLogEntries.Add(var2);
					context.ApplicationLogEntries.Add(var3);
					context.SaveChanges();
					//call get method
					var results = controller.Get();
					Assert.IsNotNull(results);
					var list = results.ToList();
					Assert.AreEqual(3, list.Count);
					var one = list[0];
					// var3 -> one
					Assert.AreEqual(var3.Id, one.Id);
					Assert.AreEqual(var3.DeviceId, one.DeviceId);
					Assert.AreEqual(var3.ApplicationId, one.ApplicationId);
					Assert.AreEqual(var3.Message, one.Message);
					Assert.AreEqual(var3.Exception, one.Exception);
					Assert.AreEqual(var3.CreatedDate, one.CreatedDate);
					var two = list[1];
					// var2 -> two
					Assert.AreEqual(var2.Id, two.Id);
					Assert.AreEqual(var2.DeviceId, two.DeviceId);
					Assert.AreEqual(var2.ApplicationId, two.ApplicationId);
					Assert.AreEqual(var2.Message, two.Message);
					Assert.AreEqual(var2.Exception, two.Exception);
					Assert.AreEqual(var2.CreatedDate, two.CreatedDate);
					var three = list[2];
					// var1 -> three
					Assert.AreEqual(var1.Id, three.Id);
					Assert.AreEqual(var1.DeviceId, three.DeviceId);
					Assert.AreEqual(var1.ApplicationId, three.ApplicationId);
					Assert.AreEqual(var1.Message, three.Message);
					Assert.AreEqual(var1.Exception, three.Exception);
					Assert.AreEqual(var1.CreatedDate, three.CreatedDate);
				}
			}
		}

		[Test]
		public void GetWithIdTest()
		{
			using (IDataContext context = new MockDataContext())
			{
				using (var controller = new ApplicationLogEntryController(context))
				{
					var var1 = new ApplicationLogEntry();
					var var2 = new ApplicationLogEntry();
					var var3 = new ApplicationLogEntry();
					//var1
					var1.Id = Guid.NewGuid();
					var1.DeviceId = 54;
					var1.ApplicationId = "jyy<J3&n4.=";
					var1.Message = "e{*_;>pl00?24/N4@i%f6*!+eyxiCW~-Z.3py)K7}lt,WmV?";
					var1.Exception = "jgI2!cQ.}rnJd?,?LS^Z$*4W([VpDP24CF&s$,/CLPl}";
					var1.CreatedDate = DateTime.Now;
					//var2
					var2.Id = Guid.NewGuid();
					var2.DeviceId = 30;
					var2.ApplicationId = "tS}}(_Eeib[p.,\"fFtZ\\7?/#&L$'_CJP{/?8,";
					var2.Message = "SM%\\yZ6vMN#\\2ba<L-]nxIXk0O'ZlbT\\cl-OBIz{MFo";
					var2.Exception = "KK,O@^x3LQ_a2A|/_K1wzC/A#F&";
					var2.CreatedDate = DateTime.Now;
					//var3
					var3.Id = Guid.NewGuid();
					var3.DeviceId = 43;
					var3.ApplicationId = "}+n0EXBMt%!}DO{Iny=clp6=3s}Q.>.DJ-cmG";
					var3.Message = "WQOCXQFhlo+74Ew,y@6u(|";
					var3.Exception = "w3dOq*[zqWmld`4";
					var3.CreatedDate = DateTime.Now;
					//Fix Order
					var order = DateTime.Now;
					var3.CreatedDate = order;
					var2.CreatedDate = order.AddDays(-1);
					var1.CreatedDate = order.AddDays(-2);
					// Add and save entities
					context.ApplicationLogEntries.Add(var1);
					context.ApplicationLogEntries.Add(var2);
					context.ApplicationLogEntries.Add(var3);
					context.SaveChanges();
					// verify
					var actual = controller.Get(var1.Id);
					Assert.IsNotNull(actual.Id);
					// var1 -> actual
					Assert.AreEqual(var1.Id, actual.Id);
					Assert.AreEqual(var1.DeviceId, actual.DeviceId);
					Assert.AreEqual(var1.ApplicationId, actual.ApplicationId);
					Assert.AreEqual(var1.Message, actual.Message);
					Assert.AreEqual(var1.Exception, actual.Exception);
					Assert.AreEqual(var1.CreatedDate, actual.CreatedDate);
					// Verify var2
					actual = controller.Get(var2.Id);
					Assert.IsNotNull(actual.Id);
					// var2 -> actual
					Assert.AreEqual(var2.Id, actual.Id);
					Assert.AreEqual(var2.DeviceId, actual.DeviceId);
					Assert.AreEqual(var2.ApplicationId, actual.ApplicationId);
					Assert.AreEqual(var2.Message, actual.Message);
					Assert.AreEqual(var2.Exception, actual.Exception);
					Assert.AreEqual(var2.CreatedDate, actual.CreatedDate);
					// Verify var3
					actual = controller.Get(var3.Id);
					Assert.IsNotNull(actual.Id);
					// var3 -> actual
					Assert.AreEqual(var3.Id, actual.Id);
					Assert.AreEqual(var3.DeviceId, actual.DeviceId);
					Assert.AreEqual(var3.ApplicationId, actual.ApplicationId);
					Assert.AreEqual(var3.Message, actual.Message);
					Assert.AreEqual(var3.Exception, actual.Exception);
					Assert.AreEqual(var3.CreatedDate, actual.CreatedDate);
				}
			}
		}
	}
}