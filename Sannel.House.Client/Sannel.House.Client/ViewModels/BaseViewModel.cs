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

		private bool isBusy;
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
				return isBusy;
			}
			protected set
			{
				Set(ref isBusy, value);
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
