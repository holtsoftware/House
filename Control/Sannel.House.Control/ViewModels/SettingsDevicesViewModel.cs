using Sannel.House.Control.Data;
using Sannel.House.Control.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

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

		public void AddNew()
		{
			IsDeviceNameEnabled = true;
			IsShortDeviceIdEnabled = true;
			CanSave = true;
			using (var context = new SqliteContext())
			{
				ShortDeviceId = (context.StoredDevices.Max(i => i.ShortId) + 1).ToString();
			}
			DeviceName = "";
		}

		public async void Save()
		{
			if (String.IsNullOrWhiteSpace(DeviceName))
			{
				MessageDialog dialog = new MessageDialog("Device Name is required");
				await dialog.ShowAsync();
				return;
			}

			uint id;
			if(!uint.TryParse(ShortDeviceId, out id))
			{
				MessageDialog dialog = new MessageDialog("Short Device Id must be a unint");
				await dialog.ShowAsync();
				return;
			}

			using (var context = new SqliteContext())
			{
				var item = context.StoredDevices.FirstOrDefault(i => i.ShortId == id);
				if(item != null)
				{
					MessageDialog dialog = new MessageDialog("There is already a device with that short id");
					await dialog.ShowAsync();
					return;
				}

				item = new StoredDevice();
				item.ShortId = id;
				item.Name = DeviceName;
				context.StoredDevices.Add(item);
				await context.SaveChangesAsync();
			}

			RefreshDevices();
		}

		private bool canSave = false;
		/// <summary>
		/// Gets or sets a value indicating whether this instance can save.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance can save; otherwise, <c>false</c>.
		/// </value>
		public bool CanSave
		{
			get { return canSave; }
			set { Set(ref canSave, value); }
		}
	}
}
