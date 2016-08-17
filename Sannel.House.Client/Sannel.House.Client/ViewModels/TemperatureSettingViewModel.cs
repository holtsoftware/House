using Sannel.House.Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Client.ViewModels
{
	public class TemperatureSettingViewModel : ErrorViewModel, ITemperatureSettingViewModel
	{
		private IServerContext server;

		public TemperatureSettingViewModel(IServerContext server, INavigationService navigationService) : base(navigationService)
		{
			this.server = server;
		}


		private int defaultCool =80;
		/// <summary>
		/// Gets or sets the DefaultCool.
		/// </summary>
		/// <value>
		/// The DefaultCool
		/// </value>
		public int DefaultCool
		{
			get
			{
				return defaultCool;
			}
			set
			{
				Set(ref defaultCool, value);
			}
		}


		private int defaultHeat = 65;


		/// <summary>
		/// Gets or sets the DefaultHeat.
		/// </summary>
		/// <value>
		/// The DefaultHeat
		/// </value>
		public int DefaultHeat
		{
			get
			{
				return defaultHeat;
			}
			set
			{
				Set(ref defaultHeat, value);
			}
		}

		public void Refresh()
		{
		}
	}
}
