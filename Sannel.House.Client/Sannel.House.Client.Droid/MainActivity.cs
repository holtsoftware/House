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
using Android.Support.V4.View;
using Android.Support.V4.App;
using Android.Content.Res;

namespace Sannel.House.Client.Droid
{
	[Activity(Label = "Sannel.House.Client.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		private INavigationService navService;
		private DrawerLayout drawerLayout;
		private RecyclerView drawerList;
		private IShellViewModel vm;
		private MainDrawerToggle drawerToggle;
		private MenuAdapter adapter;

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
			vm.PropertyChanged += vmPropertyChanged;
		}

		private void vmPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
		}

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			setup();

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
			drawerList = FindViewById<RecyclerView>(Resource.Id.left_drawer);

			drawerLayout.SetDrawerShadow(Resource.Drawable.drawer_shadow, GravityCompat.Start);
			drawerList.SetLayoutManager(new LinearLayoutManager(this));
			adapter = new MenuAdapter();
			drawerList.SetAdapter(adapter);

			// enable ActionBar app icon to behave as action to toggle nav drawer
			this.ActionBar.SetDisplayHomeAsUpEnabled(true);
			this.ActionBar.SetHomeButtonEnabled(true);
			this.ActionBar.Title = "Test";
			drawerToggle = new MainDrawerToggle(this, drawerLayout,
				Resource.Drawable.ic_drawer,
				Resource.String.drawer_open,
				Resource.String.drawer_close);

			drawerLayout.AddDrawerListener(drawerToggle);

			drawerLayout.CloseDrawer(drawerList);
			vm.NavigatedTo(null);
		}

		protected override void OnPostCreate(Bundle savedInstanceState)
		{
			base.OnPostCreate(savedInstanceState);
			drawerToggle.SyncState();
		}

		public override void OnConfigurationChanged(Configuration newConfig)
		{
			base.OnConfigurationChanged(newConfig);
			drawerToggle.OnConfigurationChanged(newConfig);
		}


		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			if (drawerToggle.OnOptionsItemSelected(item))
			{
				return true;
			}
			return base.OnOptionsItemSelected(item);
		}

		internal class MainDrawerToggle : ActionBarDrawerToggle
		{
			MainActivity owner;

			public MainDrawerToggle(MainActivity activity, DrawerLayout layout, int imgRes, int openRes, int closeRes)
				: base (activity, layout, imgRes, openRes, closeRes)
			{
				owner = activity;
			}

			public override void OnDrawerClosed(View drawerView)
			{
				owner.InvalidateOptionsMenu();
			}

			public override void OnDrawerOpened(View drawerView)
			{
				owner.InvalidateOptionsMenu();
			}
		}
	}
}

