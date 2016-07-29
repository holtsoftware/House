using Sannel.House.Thermostat.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;

namespace Sannel.House.Thermostat.Business
{
	/// <summary>
	/// This relay can be found at https://www.sparkfun.com/products/13815
	/// </summary>
	/// <seealso cref="Sannel.House.Thermostat.Base.Interfaces.IRelay" />
	public class BeefcakeRelay : IRelay
	{
		private GpioPin pin;
		private readonly int pinId;
		/// <summary>
		/// Initializes a new instance of the <see cref="BeefcakeRelay"/> class.
		/// </summary>
		/// <param name="pinId">The pin identifier.</param>
		public BeefcakeRelay(int pinId)
		{
			this.pinId = pinId;
		}

		public bool IsInitalized
		{
			get
			{
				return pin != null;
			}
		}

		/// <summary>
		/// Gets a value indicating whether the relay is on.
		/// </summary>
		/// <value>
		/// <c>true</c> if the relay is on; otherwise, <c>false</c>.
		/// </value>
		public bool IsOn
		{
			get;
			private set;
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			pin?.Dispose();
			pin = null;
		}

		/// <summary>
		/// Initializes the Relay asynchronous.
		/// </summary>
		/// <returns></returns>
		public Task<bool> InitializeAsync()
		{
			return Task.Run(() =>
			{
				GpioController controller = GpioController.GetDefault();
				if (controller == null)
				{
					return false;
				}

				pin?.Dispose();

				GpioOpenStatus status;

				if (controller.TryOpenPin(pinId, GpioSharingMode.Exclusive, out pin, out status))
				{
					pin.Write(GpioPinValue.Low);
					pin.SetDriveMode(GpioPinDriveMode.Output);
					return true;
				}

				return false;
			});
		}

		/// <summary>
		/// Turns the Relay off.
		/// </summary>
		public void TurnOff()
		{
			pin?.Write(GpioPinValue.Low);
			IsOn = false;
		}

		/// <summary>
		/// Turns the Relay on.
		/// </summary>
		public void TurnOn()
		{
			pin?.Write(GpioPinValue.High);
			IsOn = true;
		}
	}
}
