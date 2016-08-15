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
using Sannel.House.Client.Droid.Interfaces;
using Sannel.House.Client.Interfaces;

namespace Sannel.House.Client.Droid.Fragments
{
	public class LoginFragment : ErrorFragment<ILoginViewModel>, INavigationFragment
	{
		private EditText username;
		private EditText password;
		private Button loginAction;

		protected override int FragmentId
		{
			get
			{
				return Resource.Layout.LoginView;
			}
		}
		public override void OnStart()
		{
			base.OnStart();
			username = View.FindViewById<EditText>(Resource.Id.username);
			password = View.FindViewById<EditText>(Resource.Id.password);
			loginAction = View.FindViewById<Button>(Resource.Id.LoginAction);
			ViewModelHelper
				.BindText(i => i.Username, username)
				.BindText(i => i.Password, password)
				.ConnectCommand(i => i.LoginCommand, loginAction);
		}

	}
}