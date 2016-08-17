using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		float DefaultHeat
		{
			get;
		}

		/// <summary>
		/// Gets the default cool.
		/// </summary>
		/// <value>
		/// The default cool.
		/// </value>
		float DefaultCool
		{
			get;
		}

		void Refresh();
	}
}
