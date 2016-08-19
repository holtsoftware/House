using Sannel.House.Client.UWP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
			var startTimeItems = new List<TimeItem>();
			var endTimeItems = new List<TimeItem>();
			var end = new DateTime(1, 1, 2, 0, 0, 0);

			for (DateTime dt = new DateTime(1, 1, 1, 0, 0, 0); dt < end; dt = dt.AddMinutes(30))
			{
				var ti = new TimeItem
				{
					Value = dt
				};
				startTimeItems.Add(ti);
				endTimeItems.Add(ti);
			}
			endTimeItems.Add(new TimeItem { Value = end });
			StartTimeInput.ItemsSource = startTimeItems;
			EndTimeInput.ItemsSource = endTimeItems;

			Opened += TemperatureEditControl_Opened;
		}

		public DateTime StartDateTime { get; set; }

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
