using Sannel.House.Client.Interfaces;
using Sannel.House.Client.Models;
using Sannel.House.Client.UWP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Sannel.House.Client.UWP.Controls
{
	public sealed partial class TemperatureEditControl : ContentDialog
	{
		public ITemperatureEditViewModel TemperatureEditViewModel
		{
			get
			{
				return (ITemperatureEditViewModel)DataContext;
			}
		}

		private TemperatureSetting temperatureSetting;
		public TemperatureSetting TemperatureSetting
		{
			get
			{
				return temperatureSetting;
			}
			set
			{
				temperatureSetting = value;
				TemperatureEditViewModel.TemperatureSetting = value;
			}
		}

		//private void calculateEndItems()
		//{
		//	if (TemperatureSetting.StartTime.HasValue)
		//	{
		//		var end = new DateTime(1, 1, 2, 0, 0, 0);
		//		var others = TemperatureViewModel.DaySettings.Where(i => i.DayOfWeek == TemperatureSetting.DayOfWeek && i != TemperatureSetting).ToList();
		//		endTimes.Clear();

		//		for (DateTime dt = TemperatureSetting.StartTime.Value.AddMinutes(30); dt <= end; dt = dt.AddMinutes(30))
		//		{
		//			var ti = new TimeItem
		//			{
		//				Value = dt
		//			};
		//			endTimes.Add(ti);
		//			if (others.FirstOrDefault(i => dt >= i.StartTime && dt < i.EndTime) != null)
		//			{
		//				break; // stop after first item that would conflict
		//			}
		//		}
		//	}
		//	else
		//	{
		//		endTimes.Clear();
		//	}
		//}

		public TemperatureEditControl()
		{
			this.InitializeComponent();
			var coolTemps = new List<int>();
			for (int i = 85; i >= 68; i--)
			{
				coolTemps.Add(i);
			}
			var heatTemps = new List<int>();
			for (int i = 76; i >= 60; i--)
			{
				heatTemps.Add(i);
			}
			CoolTemperatureInput.ItemsSource = coolTemps;
			HeatTemperatureInput.ItemsSource = heatTemps;

			Opened += TemperatureEditControl_Opened;
		}


		private void TemperatureEditControl_Opened(ContentDialog sender, ContentDialogOpenedEventArgs args)
		{
		}

		private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
		{
		}

		private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
		{
		}

	}
}
