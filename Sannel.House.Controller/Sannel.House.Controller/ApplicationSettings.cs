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
limitations under the License.*/
using Sannel.House.Controller.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Sannel.House.Controller
{
	public class ApplicationSettings : IAppSettings
	{
		private readonly ApplicationDataContainer settings;

		public static ApplicationSettings Current { get; } = new ApplicationSettings();

		public ApplicationSettings()
		{
			settings = ApplicationData.Current.LocalSettings;
		}

		private void set<T>(T value, [CallerMemberName]String key = null)
		{
			settings.Values[key] = value;
		}

		private T get<T>([CallerMemberName]String key = null, T def = default(T))
		{
			Object v = settings.Values[key];
			if (v is T)
			{
				return (T)v;
			}
			return def;
		}

		/// <summary>
		/// Gets or sets the password.
		/// </summary>
		/// <value>
		/// The password.
		/// </value>
		public string Password
		{
			get
			{
				return get<String>();
			}

			set
			{
				set(value);
			}
		}

		/// <summary>
		/// Gets or sets the server URL.
		/// </summary>
		/// <value>
		/// The server URL.
		/// </value>
		public string ServerUrl
		{
			get
			{
				return get<String>();
			}

			set
			{
				set(value);
			}
		}

		/// <summary>
		/// Gets or sets the username.
		/// </summary>
		/// <value>
		/// The username.
		/// </value>
		public string Username
		{
			get
			{
				return get<String>();
			}

			set
			{
				set(value);
			}
		}
	}
}
