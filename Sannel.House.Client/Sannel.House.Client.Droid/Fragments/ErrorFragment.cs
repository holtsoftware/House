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
	public abstract class ErrorFragment<TViewModel> : BaseFragment<TViewModel>
		where TViewModel : class, IErrorViewModel
	{
		public IErrorViewModel ErrorViewModel
		{
			get;
			private set;
		}
		protected ArrayAdapter<String> ErrorAdapter
		{
			get;
			private set;
		}

		public override void OnStart()
		{
			base.OnStart();

			var list = this.View.FindViewById<ListView>(Resource.Id.errorView);
			if(list != null)
			{
				ErrorAdapter = new ArrayAdapter<string>(View.Context, Resource.Layout.ErrorItemLayout);
				list.Adapter = ErrorAdapter;		
			}
		}

		public override void OnStop()
		{
			base.OnStop();
			if(ErrorViewModel != null)
			{
				ErrorViewModel.ErrorKeys.CollectionChanged -= errorKeyChanged;
			}
		}

		public override void SetViewModel(IBaseViewModel vm)
		{
			base.SetViewModel(vm);
			ErrorViewModel = vm as IErrorViewModel;
			if (ErrorViewModel != null)
			{
				ErrorViewModel.ErrorKeys.CollectionChanged += errorKeyChanged;
			}
		}

		private void errorKeyChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			if(ErrorAdapter != null && ErrorViewModel != null)
			{
				ErrorAdapter.Clear();
				foreach(var key in ErrorViewModel.ErrorKeys)
				{
					var id = Resources.GetIdentifier(key, "string", View.Context.PackageName);
					ErrorAdapter.Add(Resources.GetString(id));
				}
			}
		}
	}
}