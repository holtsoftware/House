﻿/*
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Sannel.House.Control.ViewModels
{
	public class TimerViewModel
	{
		private DateTime nextHour = DateTime.MinValue;
		private DateTime nextDay = DateTime.MinValue;
		private DispatcherTimer timer = new DispatcherTimer();

		public event Action Tick;
		public event Action HourTick;
		public event Action DayTick;

		public TimerViewModel()
		{
			timer.Interval = TimeSpan.FromSeconds(10);
			timer.Tick += Timer_Tick;
			timer.Start();
		}

		private void Timer_Tick(object sender, object e)
		{
			Tick?.Invoke();
			var now = DateTime.Now;
			if(now > nextHour)
			{
				HourTick?.Invoke();
				nextHour = now.AddHours(1);
			}
			if(now > nextDay)
			{
				DayTick?.Invoke();
				nextDay = now.AddDays(1);
			}
		}
	}
}
