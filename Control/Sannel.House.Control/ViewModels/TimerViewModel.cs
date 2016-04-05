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

		private static TimerViewModel current;
		public static TimerViewModel Current
		{
			get
			{
				return current ?? (current = new TimerViewModel());
			}
		}

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
