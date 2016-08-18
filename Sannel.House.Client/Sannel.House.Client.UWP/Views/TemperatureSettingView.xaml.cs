using Sannel.House.Client.Interfaces;
using Sannel.House.Client.Models;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Sannel.House.Client.UWP.Views
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class TemperatureSettingView : BaseView
	{
		private ITemperatureSettingViewModel TempViewModel
		{
			get
			{
				return ViewModel as ITemperatureSettingViewModel;
			}
		}
		public TemperatureSettingView()
		{
			this.InitializeComponent();
		}

		private void Button_FocusDisengaged(Control sender, FocusDisengagedEventArgs args)
		{
		}

		private async void Flyout_Closed(object sender, object e)
		{

			Flyout flyout = (Flyout)sender;
			Button button = (Button)flyout.Target;

			TemperatureSetting ts = button.DataContext as TemperatureSetting;
			await TempViewModel.SaveTemperatureSettingAsync(ts);
		}
	}
}
