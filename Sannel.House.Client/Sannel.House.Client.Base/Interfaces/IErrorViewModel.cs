using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Client.Interfaces
{
	public interface IErrorViewModel : IBaseViewModel
	{
		/// <summary>
		/// Gets the error keys.
		/// The Error Key represents an error message in the Resource file.
		/// </summary>
		/// <value>
		/// The error keys.
		/// </value>
		ObservableCollection<String> ErrorKeys
		{
			get;
		}

		bool HasErrors
		{
			get;
			set;
		}
	}
}
