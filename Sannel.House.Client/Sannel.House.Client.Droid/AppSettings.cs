using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Sannel.House.Client.Interfaces;

namespace Sannel.House.Client.Droid
{
	public class AppSettings : ISettings
	{
		public const String ServerUrlKey = "sannel_house_client_server_url";
		public const String AuthzCookieKey = "sannel_house_client_authz_cookie";

		private ISharedPreferences preferences;
		public AppSettings(ISharedPreferences preferences)
		{
			this.preferences = preferences;
		}

		public string AuthzCookieValue
		{
			get
			{
				return preferences.GetString(AuthzCookieKey, null);
			}

			set
			{
				using (var edit = preferences.Edit())
				{
					edit.PutString(AuthzCookieKey, value);
					edit.Apply();
				}
			}
		}

		public Uri ServerUrl
		{
			get
			{
				var result = preferences.GetString(ServerUrlKey, null);
				Uri i;
				if(Uri.TryCreate(result, UriKind.Absolute, out i))
				{
					return i;
				}

				return null;
			}

			set
			{
				using (var edit = preferences.Edit())
				{
					edit.PutString(ServerUrlKey, value?.ToString());
					edit.Apply();
				}
			}
		}
	}
}