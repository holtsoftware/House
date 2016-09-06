using Sannel.House.Thermostat.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI;

namespace Sannel.House.Thermostat
{
	public class AppSettings : IAppSettings
	{
		private readonly ApplicationDataContainer settings;

		public static AppSettings Current { get; } = new AppSettings();

		public AppSettings()
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
		public Uri ServerUri
		{
			get
			{
				Uri i;
				if(Uri.TryCreate(get<String>(), UriKind.Absolute, out i))
				{
					return i;
				}
				return null;
			}

			set
			{
				set(value?.ToString());
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

		/// <summary>
		/// Gets or sets the device identifier.
		/// </summary>
		/// <value>
		/// The device identifier.
		/// </value>
		public int DeviceId
		{
			get
			{
				return get<int>(def: 1);
			}

			set
			{
				set(value);
			}
		}
	}
}
