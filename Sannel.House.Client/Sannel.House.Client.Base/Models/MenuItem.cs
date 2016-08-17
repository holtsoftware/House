using Sannel.House.Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Client.Models
{
	public class MenuItem
	{
		private Type navigationType;

		public String TextKey { get; set; }
		public String IconKey { get; set; }
		public bool IsBottom { get; set; }
		public Action Click { get; set; }

		public String[] Groups { get; set; }

		public MenuItem SetNavigationType<IViewModel>()
			where IViewModel : IBaseViewModel
		{
			navigationType = typeof(IViewModel);
			return this;
		}

		public void NavigateTo(INavigationService service, Object paramater = null)
		{
			if(navigationType != null)
			{
				service.Navigate(navigationType, paramater);
			}
		}
	}
}
