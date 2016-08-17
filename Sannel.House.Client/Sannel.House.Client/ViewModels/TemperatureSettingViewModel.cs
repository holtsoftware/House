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


		private float defaultCool;
		/// <summary>
		/// Gets or sets the DefaultCool.
		/// </summary>
		/// <value>
		/// The DefaultCool
		/// </value>
		public float DefaultCool
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


		private float defaultHeat;


		/// <summary>
		/// Gets or sets the DefaultHeat.
		/// </summary>
		/// <value>
		/// The DefaultHeat
		/// </value>
		public float DefaultHeat
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
