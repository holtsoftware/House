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
		private ITemperatureEditViewModel temperatureEditViewModel;
		public ITemperatureEditViewModel TemperatureEditViewModel
		{
			get
			{
				return temperatureEditViewModel ?? (temperatureEditViewModel = ViewModelLocator.TemperatureEditViewModel);
			}
		}



		public bool IsDeleting
		{
			get { return (bool)GetValue(IsDeletingProperty); }
			set { SetValue(IsDeletingProperty, value); }
		}

		// Using a DependencyProperty as the backing store for IsDeleting.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty IsDeletingProperty =
			DependencyProperty.Register("IsDeleting", typeof(bool), typeof(TemperatureEditControl), new PropertyMetadata(false));



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

			DataContext = TemperatureEditViewModel;
			Opened += TemperatureEditControl_Opened;
		}


		private void TemperatureEditControl_Opened(ContentDialog sender, ContentDialogOpenedEventArgs args)
		{
		}

		private async void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
		{
			var deferral = args.GetDeferral();
			var command = TemperatureEditViewModel.SaveTemperatureSettingCommand;
			if (command.CanExecute(null))
			{
				await command.ExecuteAsync(null);
			}
			if (TemperatureEditViewModel.HasErrors)
			{
				args.Cancel = true;
			}
			deferral.Complete();
		}

		private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
		{
		}

		private void DeleteButtonFirst_Click(object sender, RoutedEventArgs e)
		{
			IsDeleting = !IsDeleting;
		}

		private async void DeleteYesButton_Click(object sender, RoutedEventArgs e)
		{
			var command = TemperatureEditViewModel.DeleteTemperatureSettingCommand;
			if (command.CanExecute(null))
			{
				await command.ExecuteAsync(null);
			}

			Hide();
		}

		private void DeleteNoButton_Click(object sender, RoutedEventArgs e)
		{
			IsDeleting = false;
		}
	}
}
