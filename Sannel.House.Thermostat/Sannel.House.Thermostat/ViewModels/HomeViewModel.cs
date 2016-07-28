using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Sannel.House.Thermostat.ViewModels
{
	public class HomeViewModel : BaseViewModel
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="HomeViewModel"/> class.
		/// </summary>
		/// <param name="container">The container.</param>
		/// <param name="service">The service.</param>
		/// <param name="eventAggregator">The event aggregator.</param>
		public HomeViewModel(WinRTContainer container, INavigationService service, IEventAggregator eventAggregator) : base(container, service, eventAggregator)
		{
		}
	}
}
