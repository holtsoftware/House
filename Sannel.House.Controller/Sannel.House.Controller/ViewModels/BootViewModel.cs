using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Sannel.House.Controller.ViewModels
{
	public class BootViewModel : BaseViewModel
	{
		public BootViewModel(WinRTContainer container, INavigationService service, IEventAggregator eventAggregator) : base(container, service, eventAggregator)
		{
		}
	}
}
