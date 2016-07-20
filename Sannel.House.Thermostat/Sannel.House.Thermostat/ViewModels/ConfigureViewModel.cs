using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Sannel.House.Thermostat.Base.Interfaces;

namespace Sannel.House.Thermostat.ViewModels
{
	public class ConfigureViewModel : BaseViewModel
	{
		private readonly IAppSettings settings;
		public ConfigureViewModel(IAppSettings settings, WinRTContainer container, IEventAggregator eventAggregator) : base(container, eventAggregator)
		{
			this.settings = settings;
		}

		/// <summary>
		/// Gets a value indicating whether this instance is first run.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance is first run; otherwise, <c>false</c>.
		/// </value>
		public bool IsFirstRun { get; private set; } = false;
	}
}
