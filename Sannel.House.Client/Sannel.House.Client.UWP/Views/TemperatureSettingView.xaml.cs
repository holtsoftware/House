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
		public TemperatureSettingView()
		{
			this.InitializeComponent();
			var coolTemps = new List<int>();
			for(int i = 85; i >= 64; i--)
			{
				coolTemps.Add(i);
			}
			var heatTemps = new List<int>();
			for(int i=81;i >= 60; i--)
			{
				heatTemps.Add(i);
			}
			DefaultCool.ItemsSource = coolTemps;
			DefaultHeat.ItemsSource = heatTemps;
		}
	}
}
