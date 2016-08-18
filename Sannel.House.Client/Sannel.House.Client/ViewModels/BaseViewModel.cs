using Sannel.House.Client.Interfaces;
using Sannel.House.Client.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Client.ViewModels
{
	public abstract class BaseViewModel : BasePropertyChange, IBaseViewModel
	{
		protected readonly INavigationService NavigationService;
		public BaseViewModel(INavigationService navigationService)
		{
			this.NavigationService = navigationService;
		}

		/// <summary>
		/// Gets or sets the IsBusy.
		/// </summary>
		/// <value>
		/// The IsBusy
		/// </value>
		public bool IsBusy
		{
			get
			{
				return ViewModelLocator.ShellViewModel.IsBusy;
			}
			set
			{
				ViewModelLocator.ShellViewModel.IsBusy = value;
			}
		}


		private bool isBackgroundBusy;
		/// <summary>
		/// Gets or sets the IsBackgroundBusy.
		/// </summary>
		/// <value>
		/// The IsBackgroundBusy
		/// </value>
		public bool IsBackgroundBusy
		{
			get
			{
				return isBackgroundBusy;
			}
			set
			{
				Set(ref isBackgroundBusy, value);
			}
		}

		private int backgroundStackNumber;
		protected void AddBackgroudStackNumber()
		{
			backgroundStackNumber++;
			if(backgroundStackNumber > 0)
			{
				if (!IsBackgroundBusy)
				{
					IsBackgroundBusy = true;
				}
			}
		}

		protected void RemoveBackgroundStackNumber()
		{
			backgroundStackNumber--;
			if(backgroundStackNumber <= 0)
			{
				if (IsBackgroundBusy)
				{
					IsBackgroundBusy = false;
				}
			}
		}

		public virtual void NavigatedTo(Object arg)
		{

		}

		public virtual void NavigatedFrom()
		{

		}
	}
}
