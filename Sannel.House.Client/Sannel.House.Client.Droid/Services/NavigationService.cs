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
using Microsoft.Practices.Unity;
using Sannel.House.Client.Droid.Interfaces;

namespace Sannel.House.Client.Droid.Services
{
	public class NavigationService : INavigationService
	{
		private Activity activity;
		private int frameId;

		private Dictionary<Type, Type> mappings = new Dictionary<Type, Type>();

		public NavigationService(Activity activity, int frameId)
		{
			this.activity = activity;
			this.frameId = frameId;
		}

		public void RegisterFragment<IType, FType>()
			where IType : IBaseViewModel
			where FType : Fragment, INavigationFragment
		{
			ViewModelLocator.Container.RegisterType<FType>();
			mappings.Add(typeof(IType), typeof(FType));
		}

		public void Navigate<T>() where T : IBaseViewModel
		{
			Navigate<T>(null);
		}

		public void Navigate<T>(object parameter) where T : IBaseViewModel
		{
			var type = typeof(T);
			if (mappings.ContainsKey(type))
			{
				var toCreate = mappings[type];
				var instance = ViewModelLocator.Container.Resolve(toCreate) as INavigationFragment;
				T vm = ViewModelLocator.Container.Resolve<T>();
				instance.SetViewModel(vm);
				activity.FragmentManager.BeginTransaction()
					.Replace(frameId, (Fragment)instance)
					.Commit();
			}
			else
			{
				throw new Exception($"The type {type} is not mapped and cannot be navigated to.");
			}
		}
	}
}