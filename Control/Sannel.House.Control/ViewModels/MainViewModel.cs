using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Sannel.House.Control.ViewModels
{
	public class MainViewModel : Conductor<SubViewModel>.Collection.OneActive
	{
		private SettingsViewModel settingsViewModel;
		private SettingsViewModel SettingsViewModel
		{
			get
			{
				return settingsViewModel ?? (settingsViewModel = new SettingsViewModel());
			}
		}

		private HomeViewModel homeViewModel;
		private HomeViewModel HomeViewModel
		{
			get
			{
				return homeViewModel ?? (homeViewModel = new HomeViewModel());
			}
		}

		private String time;
		public String Time
		{
			get { return time; }
			set { Set(ref time, value); }
		}

		private String date;
		public String Date
		{
			get { return date; }
			set { Set(ref date, value); }
		}

		protected override void OnInitialize()
		{
			base.OnInitialize();
			TimerViewModel.Current.Tick += updateTime;
			HomeAction();
		}

		private void updateTime()
		{
			var dt = DateTime.Now;
			Date = $"{dt:d}";
			Time = $"{dt:h:mm tt}";
		}

		public void SettingsAction()
		{
			ActivateItem(SettingsViewModel);
		}

		public void HomeAction()
		{
			ActivateItem(HomeViewModel);
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
