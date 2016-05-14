using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using WinRTXamlToolkit.Tools;
using Sannel.House.Control.Data.Messages;

namespace Sannel.House.Control.Business
{
	public class TimerService
	{
		private DateTime nextHalfHour = DateTime.MinValue;
		private DateTime nextHour = DateTime.MinValue;
		private DateTime nextDay = DateTime.MinValue;
		private BackgroundTimer timer = new BackgroundTimer();
		private IEventAggregator agg;
		public TimerService(IEventAggregator aggregator)
		{
			agg = aggregator;
			timer.Interval = TimeSpan.FromSeconds(5);
			timer.Tick += tick;
			timer.Start();
		}

		private void tick(object sender, object e)
		{
			try
			{
				agg.PublishOnBackgroundThread(new TickMessage());
			}
			catch { }
			var now = DateTime.Now;
			if (now > nextHalfHour)
			{
				try
				{
					agg.PublishOnBackgroundThread(new HalfHourTickMessage());
				}
				catch { }
				nextHalfHour = now.AddMinutes(30);
			}
			if (now > nextHour)
			{
				try
				{
					agg.PublishOnBackgroundThread(new HourTickMessage());
				}
				catch { }
				nextHour = now.AddHours(1);
			}
			if (now > nextDay)
			{
				try
				{
					agg.PublishOnBackgroundThread(new DayTickMessage());
				}
				catch { }
				nextDay = now.AddDays(1);
			}
		}
	}
}
