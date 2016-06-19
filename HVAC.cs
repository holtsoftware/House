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
		private const int FAN_PIN = 22;
		private const int HEAT_PIN = 17;
		private const int COOL_PIN = 27;
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
			fan = controller.OpenPin(FAN_PIN);
			heat = controller.OpenPin(HEAT_PIN);
			cool = controller.OpenPin(COOL_PIN);
			fan.SetDriveMode(GpioPinDriveMode.OutputOpenDrainPullUp);
			heat.SetDriveMode(GpioPinDriveMode.OutputOpenDrainPullUp);
			cool.SetDriveMode(GpioPinDriveMode.OutputOpenDrainPullUp);
		}

		public void FanOn()
		{
			heat.Write(GpioPinValue.High);
			cool.Write(GpioPinValue.High);
			fan.Write(GpioPinValue.Low);
		}

		public void HeatOn()
		{
			fan.Write(GpioPinValue.High);
			cool.Write(GpioPinValue.High);
			heat.Write(GpioPinValue.Low);
		}

		public void CoolOn()
		{
			fan.Write(GpioPinValue.High);
			heat.Write(GpioPinValue.High);
			cool.Write(GpioPinValue.Low);
		}

		public void Off()
		{
			fan.Write(GpioPinValue.High);
			heat.Write(GpioPinValue.High);
			cool.Write(GpioPinValue.High);
		}

		//public async void RunTests()
		//{
		//	while (fan != null)
		//	{
		//		fan.Write(GpioPinValue.High);
		//		await Task.Delay(500);
		//		fan.Write(GpioPinValue.Low);
		//		heat.Write(GpioPinValue.High);
		//		await Task.Delay(500);
		//		heat.Write(GpioPinValue.Low);
		//		cool.Write(GpioPinValue.High);
		//		await Task.Delay(500);
		//		cool.Write(GpioPinValue.Low);
		//	}
		//}

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
