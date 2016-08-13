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
	public class LoginFragment : Fragment, INavigationFragment
	{
		private ILoginViewModel vm;
		private EditText username;
		private EditText password;
		private Button loginAction;
		private ArrayAdapter errorAdapter;
		private ViewGroup container;

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your fragment here
			
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			this.container = container;
			// Use this to return your custom view for this Fragment
			// return inflater.Inflate(Resource.Layout.YourFragment, container, false);
			return inflater.Inflate(Resource.Layout.LoginView, container, false);
		}

		public override void OnStart()
		{
			base.OnStart();
			var ev = container.FindViewById<ListView>(Resource.Id.errorView);
			errorAdapter = new ArrayAdapter<String>(container.Context, Resource.Layout.ItemLayout);
			ev.Adapter = errorAdapter;
			username = container.FindViewById<EditText>(Resource.Id.username);
			username.FocusChange += (sender, a) =>
			{
				if(vm != null)
				{
					vm.Username = username.Text;
				}
			};
			password = container.FindViewById<EditText>(Resource.Id.password);
			password.FocusChange += (sender, a) =>
			{
				if(vm != null)
				{
					vm.Password = password.Text;
				}
			};
			loginAction = container.FindViewById<Button>(Resource.Id.LoginAction);
			loginAction.Click += (sender, e) =>
			{
				if (vm != null)
				{
					if (vm.LoginCommand.CanExecute(null))
					{
						vm.LoginCommand.Execute(null);
					}
				}
			};
		}

		public void SetViewModel(IBaseViewModel vm)
		{
			this.vm = vm as ILoginViewModel;
			if (this.vm != null)
			{
				this.vm.PropertyChanged += vm_PropertyChanged;
				this.vm.ErrorKeys.CollectionChanged += ErrorKeys_CollectionChanged;
			}
		}

		private void ErrorKeys_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			if(errorAdapter != null)
			{
				errorAdapter.Clear();
				foreach(var key in vm.ErrorKeys)
				{
					var id = Resources.GetIdentifier(key, "string", container.Context.PackageName);
					errorAdapter.Add(Resources.GetString(id));
				}
			}
		}

		private void vm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
				case nameof(ILoginViewModel.Username):
					if (username != null)
					{
						username.Text = vm.Username;
					}
					break;

				case nameof(ILoginViewModel.Password):
					if(password != null)
					{
						password.Text = vm.Password;
					}
					break;
			}
		}
	}
}