using Sannel.House.Control.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Control.Business.ViewModels
{
	public class MainViewModel : BaseVM, IMainViewModel
	{
		private string date;
		public string Date
		{
			get
			{
				return date;
			}

			set
			{
				Set(nameof(Date), ref date, value);
			}
		}

		private String time;

		public string Time
		{
			get
			{
				return time;
			}

			set
			{
				Set(nameof(Time), ref time, value);
			}
		}

		public void Update()
		{
			var now = DateTime.Now;
			Date = $"{now:d}";
			Time = $"{now:h:mm tt}";
		}
	}
}
