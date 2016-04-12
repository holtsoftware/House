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
using Caliburn.Micro;
using Sannel.House.Control.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Control.ViewModels
{
	public class SettingsViewModel : SubViewModel
	{
		protected override void OnInitialize()
		{
			base.OnInitialize();
			wundergroundApiKey = AppSettings.Current.WUndergroundApiKey;
			wundergroundState = AppSettings.Current.WUndergroundState;
			wundergroundCity = AppSettings.Current.WUndergroundCity;
		}

		private String wundergroundApiKey;

		public String WUndergroundApiKey
		{
			get { return wundergroundApiKey; }
			set
			{
				AppSettings.Current.WUndergroundApiKey = value;
				Set(ref wundergroundApiKey, value);
			}
		}

		private String wundergroundState;

		public String WUndergroundState
		{
			get { return wundergroundState; }
			set
			{
				AppSettings.Current.WUndergroundState = value;
				Set(ref wundergroundState, value);
			}
		}

		private String wundergroundCity;

		public String WUndergroundCity
		{
			get
			{
				return wundergroundCity;
			}
			set
			{
				AppSettings.Current.WUndergroundCity = value;
				Set(ref wundergroundCity, value);
			}
		}


	}
}
