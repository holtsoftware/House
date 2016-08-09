using Sannel.House.Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Client.ViewModels
{
	public class SettingsViewModel : BaseViewModel, ISettingsViewModel
	{
		private ISettings settings;

		public SettingsViewModel(ISettings settings)
		{
			this.settings = settings;
		}

		/// <summary>
		/// Gets or sets the server URL.
		/// </summary>
		/// <value>
		/// The server URL.
		/// </value>
		public String ServerUrl
		{
			get
			{
				return settings.ServerUrl?.ToString();
			}

			set
			{
				Uri i;
				if(Uri.TryCreate(value, UriKind.Absolute, out i))
				{
					settings.ServerUrl = i;
					NotifyPropertyChanged();
				}
			}
		}
	}
}
