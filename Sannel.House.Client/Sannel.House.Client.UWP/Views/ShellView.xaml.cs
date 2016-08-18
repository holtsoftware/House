using Sannel.House.Client.Interfaces;
using Sannel.House.Client.Models;
using Sannel.House.Client.UWP.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Sannel.House.Client.UWP.Views
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class ShellView : BaseView
	{
		public IShellViewModel ShellViewModel
		{
			get
			{
				return DataContext as IShellViewModel;
			}
		}

		public ShellView()
		{
			this.InitializeComponent();
			NavigationService service = ViewModelLocator.NavigationService as NavigationService;
			if (service != null)
			{
				service.Frame = MainFrame;
			}
		}

		private void ListView_ItemClick(object sender, ItemClickEventArgs e)
		{
			MenuItem mi = e.ClickedItem as MenuItem;
			ShellViewModel.MenuItemClick(mi);
		}
	}
}
