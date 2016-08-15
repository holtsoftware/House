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

namespace Sannel.House.Client.Droid.Fragments
{
	public class HomeFragment : BaseFragment<IHomeViewModel>
	{
		protected override int FragmentId
		{
			get
			{
				return Resource.Layout.HomeView;
			}
		}
	}
}