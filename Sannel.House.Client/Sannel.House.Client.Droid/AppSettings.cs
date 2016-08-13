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
		public string AuthzCookieValue
		{
			get;

			set;
		}

		public Uri ServerUrl
		{
			get;

			set;
		} = new Uri("http://192.168.1.11:5000");
	}
}