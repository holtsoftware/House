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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Sannel.House.Client.UWP.Controls
{
	public sealed partial class TemperaturePicker : UserControl
	{
		public TemperaturePicker()
		{
			this.InitializeComponent();
			var coolTemps = new List<int>();
			for(int i = 85; i >= 68; i--)
			{
				coolTemps.Add(i);
			}
			var heatTemps = new List<int>();
			for(int i=76;i >= 60; i--)
			{
				heatTemps.Add(i);
			}
			CoolPicker.ItemsSource = coolTemps;
			HeatPicker.ItemsSource = heatTemps;
		}
	}
}
