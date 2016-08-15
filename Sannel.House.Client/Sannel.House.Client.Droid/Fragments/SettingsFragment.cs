using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Preferences;
using Sannel.House.Client.Droid.Interfaces;
using Sannel.House.Client.Interfaces;

namespace Sannel.House.Client.Droid.Fragments
{

	public class SettingsFragment : ErrorFragment<ISettingsViewModel>
	{
		private TextView serverUrl;
		private Button continueAction;

		protected override int FragmentId
		{
			get
			{
				return Resource.Layout.SettingsView;
			}
		}

		public override void OnStart()
		{
			base.OnStart();
			serverUrl = View.FindViewById<TextView>(Resource.Id.serverUrl);
			continueAction = View.FindViewById<Button>(Resource.Id.continueAction);
			ViewModelHelper
				.BindText(i => i.ServerUrl, serverUrl)
				.ConnectCommand(i => i.ContinueCommand, continueAction);
		}
	}
}