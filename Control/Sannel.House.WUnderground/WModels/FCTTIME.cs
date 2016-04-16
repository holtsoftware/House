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
	public class FCTTIME
	{
		public string hour { get; set; }
		public string hour_padded { get; set; }
		public string min { get; set; }
		public string sec { get; set; }
		public string year { get; set; }
		public string mon { get; set; }
		public string mon_padded { get; set; }
		public string mon_abbrev { get; set; }
		public string mday { get; set; }
		public string mday_padded { get; set; }
		public string yday { get; set; }
		public string isdst { get; set; }
		public string epoch { get; set; }
		public string pretty { get; set; }
		public string civil { get; set; }
		public string month_name { get; set; }
		public string month_name_abbrev { get; set; }
		public string weekday_name { get; set; }
		public string weekday_name_night { get; set; }
		public string weekday_name_abbrev { get; set; }
		public string weekday_name_unlang { get; set; }
		public string weekday_name_night_unlang { get; set; }
		public string ampm { get; set; }
		public string tz { get; set; }
		public string age { get; set; }
	}
}
