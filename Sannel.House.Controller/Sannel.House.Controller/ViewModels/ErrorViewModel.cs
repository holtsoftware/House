/*
Copyright 2016 Adam Holt

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

	http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Caliburn.Micro;

namespace Sannel.House.Controller.ViewModels
{
	public abstract class ErrorViewModel : BaseViewModel
	{
		public ErrorViewModel(WinRTContainer container, INavigationService service, IEventAggregator eventAggregator) : base(container, service, eventAggregator)
		{
			Errors.CollectionChanged += Errors_CollectionChanged;
		}

		private void Errors_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			HasErrors = Errors.Count > 0;
		}

		public ObservableCollection<String> Errors
		{
			get;
		} = new ObservableCollection<String>();


		private bool hasErrors;
		/// <summary>
		/// Gets or sets the HasErrors
		/// </summary>
		/// <value>
		/// The HasErrors
		/// </value>
		public bool HasErrors
		{
			get
			{
				return hasErrors;
			}
			set
			{
				Set(ref hasErrors, value);
			}
		}
	}
}
