using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.AppService;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Sannel.House.Controller
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainPage : Page
	{
		public MainPage()
		{
			this.InitializeComponent();
		}

		protected override async void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			var connection = new AppServiceConnection();
			connection.AppServiceName = "Sannel.House.Logging";
			connection.PackageFamilyName = "Sannel.House.Logging_s9vwb96cpt7d6";
			AppServiceConnectionStatus status = await connection.OpenAsync();
			if(status == AppServiceConnectionStatus.Success)
			{
				ValueSet v = new ValueSet();
				v.Add("Test", "Test");
				await connection.SendMessageAsync(v);
			}
		}
	}
}
