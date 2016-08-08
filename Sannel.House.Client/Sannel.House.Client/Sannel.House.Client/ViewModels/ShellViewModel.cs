using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Caliburn.Micro.Xamarin.Forms;
using Xamarin.Forms;

namespace Sannel.House.Client.ViewModels
{
	public class ShellViewModel : BaseViewModel
	{
		public ShellViewModel(IEventAggregator ea, INavigationService navService) : base(ea, navService)
		{
		}

		public void SetupNavigationService(Frame frame)
		{

		}
	}
}
