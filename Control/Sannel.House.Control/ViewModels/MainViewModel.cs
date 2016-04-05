using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Control.ViewModels
{
	public class MainViewModel : ViewModelBase
	{
		public MainViewModel(INavigationService nav) : base(nav) { }

		private String myMessage;
		public String MyMessage
		{
			get
			{
				return myMessage;
			}
			set
			{
				Set(ref myMessage, value);				
			}
		}

		public void SayHelloAction()
		{
			MyMessage = DateTime.Now.ToString();
		}
	}
}
