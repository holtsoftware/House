using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Sannel.House.Thermostat.Base.Interfaces;

namespace Sannel.House.Thermostat.ViewModels
{
	public class BootViewModel : BaseViewModel
	{
		private readonly IAppSettings settings;
		private readonly IServerSource server;
		private readonly IDataContext dataContext;
		/// <summary>
		/// Initializes a new instance of the <see cref="BootViewModel"/> class.
		/// </summary>
		/// <param name="settings">The settings.</param>
		/// <param name="server">The server.</param>
		/// <param name="dataContext">The data context.</param>
		/// <param name="container">The container.</param>
		/// <param name="eventAggregator">The event aggregator.</param>
		public BootViewModel(IAppSettings settings, IServerSource server, IDataContext dataContext, WinRTContainer container, IEventAggregator eventAggregator) : base(container, eventAggregator)
		{
			this.settings = settings;
			this.server = server;
			this.dataContext = dataContext;
		}

		protected override async void OnActivate()
		{
			base.OnActivate();
			await loadFromServerAsync();
		}

		private async Task loadFromServerAsync()
		{
			
		}
	}
}
