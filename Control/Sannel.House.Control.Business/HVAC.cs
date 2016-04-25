using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;

namespace Sannel.House.Control.Business
{
	public class HVAC : IDisposable
	{
		private GpioController controller;
		private GpioPin fan;
		private GpioPin heat;
		private GpioPin cool;

		private static bool? isSupported;
		public static bool IsSupported
		{
			get
			{
				return (isSupported ?? (isSupported = Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Devices.Gpio.GpioController")) == true);
			}
		}

		public HVAC()
		{
			controller = GpioController.GetDefault();
			fan = controller.OpenPin(22);
			heat = controller.OpenPin(17);
			cool = controller.OpenPin(27);
			fan.Write(GpioPinValue.Low);
			fan.SetDriveMode(GpioPinDriveMode.Output);
			heat.Write(GpioPinValue.Low);
			heat.SetDriveMode(GpioPinDriveMode.Output);
			cool.Write(GpioPinValue.Low);
			cool.SetDriveMode(GpioPinDriveMode.Output);
		}

		public async void RunTests()
		{
			while (fan != null)
			{
				fan.Write(GpioPinValue.High);
				await Task.Delay(500);
				fan.Write(GpioPinValue.Low);
				heat.Write(GpioPinValue.High);
				await Task.Delay(500);
				heat.Write(GpioPinValue.Low);
				cool.Write(GpioPinValue.High);
				await Task.Delay(500);
				cool.Write(GpioPinValue.Low);
			}
		}

		public void Dispose()
		{
			fan?.Dispose();
			fan = null;
			heat?.Dispose();
			heat = null;
			cool?.Dispose();
			cool = null;
		}
	}
}
