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
using Sannel.House.Thermostat.Base.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Sannel.House.Thermostat.Services
{
    public class TimerService
    {
        private readonly IEventAggregator aggregator;
        private readonly DispatcherTimer timer;
        private DateTime nextMinute = DateTime.MinValue;
        private DateTime next30Minutes = DateTime.MinValue;
        private DateTime nextHour = DateTime.MinValue;
        private DateTime nextDay = DateTime.MinValue;

        public TimerService(IEventAggregator aggregator)
        {
            this.aggregator = aggregator;
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(10);
            timer.Start();
        }

        private void Timer_Tick(object sender, object e)
        {
            aggregator.PublishOnUIThread(new Timer10SecondsMessage());
            var now = DateTime.Now;
            if(nextMinute < now)
            {
                aggregator.PublishOnUIThread(new Timer1MinuteMessage());
                nextMinute = DateTime.Now.AddMinutes(1);
            }
            if(next30Minutes < now)
            {
                aggregator.PublishOnUIThread(new Timer30MinutesMessage());
                next30Minutes = DateTime.Now.AddMinutes(30);
            }
            if(nextHour < now)
            {
                aggregator.PublishOnUIThread(new Timer1HourMessage());
                nextHour = DateTime.Now.AddHours(1);
            }
            if(nextDay < now)
            {
                aggregator.PublishOnUIThread(new Timer1DayMessage());
                nextDay = DateTime.Now.AddDays(1);
            }
        }
    }
}
