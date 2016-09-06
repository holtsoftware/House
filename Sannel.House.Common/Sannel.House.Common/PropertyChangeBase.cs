using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House
{
	public class PropertyChangeBase : System.ComponentModel.INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected void NotifyOfPropertyChange([CallerMemberName]String propName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
		}

		protected void Set<T>(ref T dest, T source, [CallerMemberName]String propName = null)
		{

			if (!Object.Equals(dest, source))
			{
				dest = source;
				NotifyOfPropertyChange(propName);
			}
		}
	}
}
