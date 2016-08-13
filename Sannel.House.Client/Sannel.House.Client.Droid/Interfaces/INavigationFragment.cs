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

namespace Sannel.House.Client.Droid.Interfaces
{
	public interface INavigationFragment
	{
		void SetViewModel(IBaseViewModel vm);
	}
}