using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sannel.House.Client.Interfaces
{
	public interface ISettingsViewModel : IErrorViewModel
	{
		String ServerUrl
		{
			get;
			set;
		}

		/// <summary>
		/// Gets the continue command used to go to the next step.
		/// </summary>
		/// <value>
		/// The continue command.
		/// </value>
		ICommand ContinueCommand
		{
			get;
		}
	}
}
