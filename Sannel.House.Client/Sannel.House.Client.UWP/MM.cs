﻿/*
   Copyright 2016 ParticleNET

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
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace Sannel.House.Client.UWP
{
	public class MM
	{
		public static MM M { get; } = new MM();

		protected static ResourceLoader loader;

		public MM()
		{

			loader = loader ?? ResourceLoader.GetForCurrentView("Resources"); // if this has already been loaded use that one
		}

		public String this[String key]
		{
			get
			{
				return GetString(key);
			}
		}

		public String GetString(String key)
		{
			return loader.GetString(key);
		}
	}
}