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
				if(temperatureSetting != null)
				{
					temperatureSetting.PropertyChanged -= temperatureSetting_PropertyChanged;
				}
				temperatureSetting = value;
				TemperatureEditViewModel.TemperatureSetting = value;
				value.PropertyChanged += temperatureSetting_PropertyChanged;
			}
		}

		private void temperatureSetting_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if(String.Compare(e.PropertyName, nameof(TemperatureSetting.StartTime)) == 0)
			{
				StartTimeInput.SelectedItem = temperatureSetting.StartTime;
			}
		}

		

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
			TemperatureSetting.NotifyPropertyChanged(nameof(TemperatureSetting.StartTime));
		}

		private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
		{
		}

		private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
		{
		}

		private void StartTimeInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			DateTime? st = StartTimeInput.SelectedItem as DateTime?;
			if(st != TemperatureSetting.StartTime)
			{
				TemperatureSetting.StartTime = st;
			}
		}
	}
}
