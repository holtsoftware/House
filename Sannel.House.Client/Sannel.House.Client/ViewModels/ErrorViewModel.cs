using Sannel.House.Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Sannel.House.Client.ViewModels
{
	public abstract class ErrorViewModel : BaseViewModel, IErrorViewModel
	{
		public ErrorViewModel(INavigationService navigationService) : base(navigationService)
		{
			ErrorKeys.CollectionChanged += errorKeysChanged;
		}

		private void errorKeysChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			HasErrors = ErrorKeys.Count > 0;
		}

		/// <summary>
		/// Gets the error keys.
		/// The Error Key represents an error message in the Resource file.
		/// </summary>
		/// <value>
		/// The error keys.
		/// </value>
		public ObservableCollection<String> ErrorKeys
		{
			get;
		} = new ObservableCollection<String>();


		private bool hasErrors;
		/// <summary>
		/// Gets or sets the HasErrors.
		/// </summary>
		/// <value>
		/// The HasErrors
		/// </value>
		public bool HasErrors
		{
			get
			{
				return hasErrors;
			}
			set
			{
				Set(ref hasErrors, value);
			}
		}
	}
}
