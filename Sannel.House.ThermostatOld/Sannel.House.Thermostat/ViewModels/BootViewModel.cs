using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Sannel.House.Thermostat.Base.Interfaces;
using System.Collections.ObjectModel;

namespace Sannel.House.Thermostat.ViewModels
{
	public class BootViewModel : BaseViewModel
	{
		private readonly ISyncService syncService;
		private readonly IDataContext context;
		/// <summary>
		/// Initializes a new instance of the <see cref="BootViewModel"/> class.
		/// </summary>
		/// <param name="settings">The settings.</param>
		/// <param name="server">The server.</param>
		/// <param name="dataContext">The data context.</param>
		/// <param name="container">The container.</param>
		/// <param name="eventAggregator">The event aggregator.</param>
		public BootViewModel(ISyncService syncService, IDataContext context, WinRTContainer container, INavigationService service, IEventAggregator eventAggregator) 
			: base(container, service, eventAggregator)
		{
			this.syncService = syncService;
			this.context = context;
		}

		/// <summary>
		/// Gets the boot log.
		/// </summary>
		/// <value>
		/// The boot log.
		/// </value>
		public ObservableCollection<String> BootLog
		{
			get;
			private set;
		} = new ObservableCollection<String>();

		


		protected override async void OnActivate()
		{
			base.OnActivate();
			syncService.LogMessage += syncService_LogMessage;
			BootLog.Clear();
			if(await syncService.LoginAsync())
			{
				await syncService.SyncDevicesAsync();
			}

			if(context.Devices.FirstOrDefault(i => i.Id == 1) != null)
			{
				App.HasBooted = true;
				navigationService.For<HomeViewModel>().Navigate();
			}
			else
			{
				syncService_LogMessage(this, new Base.Models.LogEventArgs
				{
					Message = "Not configured enough to boot please ensure the servers is up and reboot."
				});
			}
		}

		private void syncService_LogMessage(object sender, Base.Models.LogEventArgs e)
		{
			BootLog.Insert(0, $"{DateTime.Now} - {e.Message}");
		}

		protected override void OnDeactivate(bool close)
		{
			base.OnDeactivate(close);
			syncService.LogMessage -= syncService_LogMessage;
		}
	}
}
