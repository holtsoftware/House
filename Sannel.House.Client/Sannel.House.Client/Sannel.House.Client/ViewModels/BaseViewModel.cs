using Caliburn.Micro;
using Caliburn.Micro.Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Client.ViewModels
{
	public abstract class BaseViewModel : Screen
	{
		private INavigationService navService;
		private readonly IEventAggregator eventAggregator;

		public BaseViewModel(IEventAggregator ea, INavigationService navService)
		{
			this.eventAggregator = ea;
			this.navService = navService;
		}

		protected override void OnActivate()
		{
			base.OnActivate();
			eventAggregator.Subscribe(this);
		}

		protected override void OnDeactivate(bool close)
		{
			base.OnDeactivate(close);
			eventAggregator.Unsubscribe(this);
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
