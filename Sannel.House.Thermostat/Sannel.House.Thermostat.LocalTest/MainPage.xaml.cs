using Sannel.House.Thermostat.Buisness;
using Sannel.House.Thermostat.Interfaces;
using Sannel.House.Thermostat.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Sannel.House.Thermostat.LocalTest
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainPage : Page
	{
		public ThermostatController Controller
		{
			get;
		}

		public TemperatureSensor Sensor
		{
			get;
		}

		public ObservableCollection<TemperatureEntry> Entries
		{
			get;
		} = new ObservableCollection<TemperatureEntry>();
		
		public MainPage()
		{
			Sensor = App.Container.GetInstance<TemperatureSensor>();
			Controller = App.Container.GetInstance<ThermostatController>();
			this.InitializeComponent();
			refreshList();
		}

		private void refreshList()
		{
			Entries.Clear();
			foreach(var v in App.Container.GetInstance<IDataContext>().TemperatureEntries.OrderByDescending(i => i.CreatedDateTime))
			{
				Entries.Add(v);
			}
		}

		private void Tick_Click(object sender, RoutedEventArgs e)
		{
			Controller.ProcessSensors();
			refreshList();
		}
	}
}
