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
   limitations under the License.
*/
using Caliburn.Micro;
using Sannel.House.Control.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Control.ViewModels
{
	public class SettingsViewModel : ViewModelBase
	{
		private WinRTContainer container;
		public SettingsViewModel(WinRTContainer container)
		{
			this.container = container;
		}

		protected override void OnActivate()
		{
			base.OnActivate();
			WUnderground();
		}

		public void WUnderground()
		{
			ActivateItem(container.GetInstance<SettingsWUndergroundViewModel>());
		}

		public void Devices()
		{
			ActivateItem(container.GetInstance<SettingsDevicesViewModel>());
		}
	}
}
