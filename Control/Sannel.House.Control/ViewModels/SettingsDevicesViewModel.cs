using Sannel.House.Control.Data;
using Sannel.House.Control.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Control.ViewModels
{
	public class SettingsDevicesViewModel : SubViewModel
	{
		private ObservableCollection<StoredDevice> devices = new ObservableCollection<StoredDevice>();
		public ObservableCollection<StoredDevice> Devices
		{
			get
			{
				return devices;
			}
		}

		public void RefreshDevices()
		{
			devices.Clear();
			using (var context = new SqliteContext())
			{
				foreach (var i in context.StoredDevices.OrderBy(i => i.ShortId))
				{
					devices.Add(i);
				}
			}
		}

		private String shortDeviceId;
		public String ShortDeviceId
		{
			get { return shortDeviceId; }
			set { Set(ref shortDeviceId, value); }
		}

		private bool isShortDeviceIdEnabled = false;
		public bool IsShortDeviceIdEnabled
		{
			get { return isShortDeviceIdEnabled; }
			set { Set(ref isShortDeviceIdEnabled, value); }
		}

		private String deviceName;
		public String DeviceName
		{
			get { return deviceName; }
			set { Set(ref deviceName, value); }
		}

		private bool isDeviceNameEnabled = false;
		public bool IsDeviceNameEnabled
		{
			get { return isDeviceNameEnabled; }
			set { Set(ref isDeviceNameEnabled, value); }
		}
	}
}
