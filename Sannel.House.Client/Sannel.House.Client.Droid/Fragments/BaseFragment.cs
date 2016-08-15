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
using Sannel.House.Client.Droid.Helpers;

namespace Sannel.House.Client.Droid.Fragments
{
	public abstract class BaseFragment<TViewModel> : Fragment, INavigationFragment
		where TViewModel : class, IBaseViewModel
	{
		protected View BusyView
		{
			get;
			set;
		}

		protected ViewModelHelper<TViewModel> ViewModelHelper
		{
			get;
			private set;
		}
		/// <summary>
		/// Gets the fragment identifier.
		/// </summary>
		/// <value>
		/// The fragment identifier.
		/// </value>
		protected abstract int FragmentId
		{
			get;
		}

		protected ViewGroup Container
		{
			get;
			set;
		}

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			Container = container;
			// Use this to return your custom view for this Fragment
			// return inflater.Inflate(Resource.Layout.YourFragment, container, false);
			if(FragmentId > 0)
			{
				return inflater.Inflate(FragmentId, container, false);
			}

			return base.OnCreateView(inflater, container, savedInstanceState);
		}

		public override void OnStart()
		{
			base.OnStart();
			BusyView = Container.RootView.FindViewById<View>(Resource.Id.busyOverlay);
			if(BusyView != null)
			{
				ViewModelHelper.BindVisible(i => i.IsBusy, BusyView, true);
			}
		}

		public override void OnStop()
		{
			base.OnStop();
			ViewModelHelper?.CleanUp();
			if(BusyView != null)
			{
				BusyView.Visibility = ViewStates.Gone;
			}
		}

		public virtual void SetViewModel(IBaseViewModel vm)
		{
			ViewModelHelper = new ViewModelHelper<TViewModel>(vm as TViewModel);
		}
	}
}