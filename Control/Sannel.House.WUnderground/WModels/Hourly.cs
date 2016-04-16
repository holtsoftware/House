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
	public class Hourly
	{
		public Response response { get; set; }
		public List<HourlyForecast> hourly_forecast { get; set; }

		public class Features
		{
			public int hourly { get; set; }
		}

		public class Response
		{
			public string version { get; set; }
			public string termsofService { get; set; }
			public Features features { get; set; }
		}

		public class Wdir
		{
			public string dir { get; set; }
			public string degrees { get; set; }
		}

		public class HourlyForecast
		{
			public FCTTIME FCTTIME { get; set; }
			public Temp temp { get; set; }
			public Temp dewpoint { get; set; }
			public string condition { get; set; }
			public string icon { get; set; }
			public string icon_url { get; set; }
			public string fctcode { get; set; }
			public string sky { get; set; }
			public Temp wspd { get; set; }
			public Wdir wdir { get; set; }
			public string wx { get; set; }
			public string uvi { get; set; }
			public string humidity { get; set; }
			public Temp windchill { get; set; }
			public Temp heatindex { get; set; }
			public Temp feelslike { get; set; }
			public Temp qpf { get; set; }
			public Temp snow { get; set; }
			public string pop { get; set; }
			public Temp mslp { get; set; }
		}
	}
}
