using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Client.Models
{
	public abstract class BasePropertyChange : System.ComponentModel.INotifyPropertyChanged
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
	}
}
