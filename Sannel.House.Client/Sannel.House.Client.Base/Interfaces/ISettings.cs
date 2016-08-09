using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Client.Interfaces
{
	/// <summary>
	/// The settings for the application.
	/// </summary>
	public interface ISettings
	{
		/// <summary>
		/// Gets or sets the server URL.
		/// </summary>
		/// <value>
		/// The server URL.
		/// </value>
		Uri ServerUrl
		{
			get;
			set;
		}
	}
}
