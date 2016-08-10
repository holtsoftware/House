using Sannel.House.Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Sannel.House.Client.UWP
{
	public class AppSettings : ISettings
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
		/// Gets or sets the server URL.
		/// </summary>
		/// <value>
		/// The server URL.
		/// </value>
		public Uri ServerUrl
		{
			get
			{
				var value = get<String>();
				if(value != null)
				{
					Uri val;
					if(Uri.TryCreate(value, UriKind.Absolute, out val))
					{
						return val;
					}
				}

				return null;
			}
			set
			{
				set<String>(value?.ToString());
			}
		}

		/// <summary>
		/// Gets or sets the authz cookie value.
		/// </summary>
		/// <value>
		/// The authz cookie value.
		/// </value>
		public String AuthzCookieValue
		{
			get
			{
				return get<String>();
			}
			set
			{
				set<String>(value);
			}
		}

	}
}
