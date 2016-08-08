using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Caliburn.Micro.Xamarin.Forms;

namespace Sannel.House.Client.ViewModels
{
	public class LoginViewModel : BaseViewModel
	{
		public LoginViewModel(IEventAggregator ea, INavigationService navService) : base(ea, navService)
		{
		}
	}
}
