using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sannel.House.Client.Interfaces
{
	public interface ITemperatureSettingViewModel : IErrorViewModel
	{
		/// <summary>
		/// Gets the default heat.
		/// </summary>
		/// <value>
		/// The default heat.
		/// </value>
		int DefaultHeat
		{
			get;
		}

		/// <summary>
		/// Gets the default cool.
		/// </summary>
		/// <value>
		/// The default cool.
		/// </value>
		int DefaultCool
		{
			get;
		}

		/// <summary>
		/// Refreshes this instance.
		/// </summary>
		void Refresh();

		/// <summary>
		/// Gets the update default command.
		/// </summary>
		/// <value>
		/// The update default command.
		/// </value>
		ICommand UpdateDefaultCommand { get; }
	}
}
