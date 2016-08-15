using GalaSoft.MvvmLight.Command;
using Sannel.House.Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sannel.House.Client.ViewModels
{
	public class SettingsViewModel : ErrorViewModel, ISettingsViewModel
	{
		public const String SERVERURLERROR = "ServerUrlError";
		private ISettings settings;

		public SettingsViewModel(ISettings settings,INavigationService service) : base(service)
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

		private bool verifyMe()
		{
			ErrorKeys.Clear();
			if(settings.ServerUrl == null)
			{
				ErrorKeys.Add(SERVERURLERROR);
			}

			return ErrorKeys.Count == 0;
		}

		private void command()
		{
			IsBusy = true;
			if(verifyMe())
			{
				NavigationService.Navigate<ILoginViewModel>();
			}
			IsBusy = false;
		}

		private RelayCommand continueCommand;

		/// <summary>
		/// Gets the continue command used to go to the next step.
		/// </summary>
		/// <value>
		/// The continue command.
		/// </value>
		public ICommand ContinueCommand
		{
			get
			{
				return continueCommand ?? (continueCommand = new RelayCommand(command));
			}
		}
	}
}
