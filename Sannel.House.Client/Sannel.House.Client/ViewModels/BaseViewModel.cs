using Sannel.House.Client.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Client.ViewModels
{
	public abstract class BaseViewModel : System.ComponentModel.INotifyPropertyChanged, IBaseViewModel
	{
		public event PropertyChangedEventHandler PropertyChanged;
		protected void Set<T>(ref T dest, T source, [CallerMemberName]String propName = null)
		{

			if (!Object.Equals(dest, source))
			{
				dest = source;
				NotifyPropertyChanged(propName);
			}
		}

		protected void NotifyPropertyChanged([CallerMemberName]String propName = null)
		{
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
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
