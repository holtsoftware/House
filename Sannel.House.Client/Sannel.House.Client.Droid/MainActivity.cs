using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Sannel.House.Client.Interfaces;
using Microsoft.Practices.Unity;
using Sannel.House.Client.Droid.Services;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Sannel.House.Client.Droid.Fragments;
using Android.Preferences;

namespace Sannel.House.Client.Droid
{
	[Activity(Label = "Sannel.House.Client.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		private INavigationService navService;
		private DrawerLayout drawerLayout;
		private RecyclerView drawerList;
		private IShellViewModel vm;

		private void setup()
		{
			var ns = new NavigationService(this, Resource.Id.content_frame);
			navService = ns;

			ns.RegisterFragment<ISettingsViewModel, SettingsFragment>();
			ns.RegisterFragment<ILoginViewModel, LoginFragment>();
			ns.RegisterFragment<IHomeViewModel, HomeFragment>();

			ViewModelLocator.Container.RegisterInstance<INavigationService>(navService);
			var container = ViewModelLocator.Container;

			ISharedPreferences prefs =  PreferenceManager.GetDefaultSharedPreferences(this);
			var settings = new AppSettings(prefs);
			settings.ServerUrl = null;

			container.RegisterInstance<ISettings>(settings);

			vm = container.Resolve<IShellViewModel>();
		}

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			setup();

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
			drawerList = FindViewById<RecyclerView>(Resource.Id.left_drawer);

			// enable ActionBar app icon to behave as action to toggle nav drawer
			this.ActionBar.SetDisplayHomeAsUpEnabled(true);
			this.ActionBar.SetHomeButtonEnabled(true);

			vm.NavigatedTo(null);
		}
	}
}

