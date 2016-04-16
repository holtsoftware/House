/*
   Copyright 2016 Adam Holt

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

	   http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.WUnderground.WModels
{
	public class Astronomy
	{
		public Response response { get; set; }
		public MoonPhase moon_phase { get; set; }

		public class Features
		{
			public int astronomy { get; set; }
		}

		public class Response
		{
			public string version { get; set; }
			public string termsofService { get; set; }
			public Features features { get; set; }
		}

		public class MoonPhase
		{
			public string percentIlluminated { get; set; }
			public string ageOfMoon { get; set; }
			public DayTime current_time { get; set; }
			public DayTime sunrise { get; set; }
			public DayTime sunset { get; set; }
		}
	}
}
