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
using Caliburn.Micro;
using System;
using System.Runtime.CompilerServices;

namespace Sannel.House.Thermostat.ViewModels
{
    public abstract class BaseViewModel : Screen
    {
        protected readonly WinRTContainer container;
        protected readonly IEventAggregator eventAggregator;

        public BaseViewModel(WinRTContainer container, IEventAggregator eventAggregator)
        {
            this.container = container;
            this.eventAggregator = eventAggregator;
        }

		private bool isBusy;
		/// <summary>
		/// Gets or sets a value indicating whether this instance is busy.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance is busy; otherwise, <c>false</c>.
		/// </value>
		public bool IsBusy
		{
			get
			{
				return isBusy;
			}
			set
			{
				Set(ref isBusy, value);
			}
		}


        protected void Set<T>(ref T dest, T source, [CallerMemberName]String propName = null)
        {

            if (!Object.Equals(dest, source))
            {
                dest = source;
                NotifyOfPropertyChange(propName);
            }
        }
    }
}
