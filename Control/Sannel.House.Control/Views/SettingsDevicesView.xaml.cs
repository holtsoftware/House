using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

namespace Sannel.House.Control.Views
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class SettingsDevicesView : Page
	{
		public SettingsDevicesView()
		{
			this.InitializeComponent();
		}

		private void TextBox_KeyDown(object sender, KeyRoutedEventArgs e)
		{
			switch (e.Key)
			{
				case Windows.System.VirtualKey.Number0:
				case Windows.System.VirtualKey.Number1:
				case Windows.System.VirtualKey.Number2:
				case Windows.System.VirtualKey.Number3:
				case Windows.System.VirtualKey.Number4:
				case Windows.System.VirtualKey.Number5:
				case Windows.System.VirtualKey.Number6:
				case Windows.System.VirtualKey.Number7:
				case Windows.System.VirtualKey.Number8:
				case Windows.System.VirtualKey.Number9:
				case Windows.System.VirtualKey.NumberPad0:
				case Windows.System.VirtualKey.NumberPad1:
				case Windows.System.VirtualKey.NumberPad2:
				case Windows.System.VirtualKey.NumberPad3:
				case Windows.System.VirtualKey.NumberPad4:
				case Windows.System.VirtualKey.NumberPad5:
				case Windows.System.VirtualKey.NumberPad6:
				case Windows.System.VirtualKey.NumberPad7:
				case Windows.System.VirtualKey.NumberPad8:
				case Windows.System.VirtualKey.NumberPad9:
					e.Handled = false;
					break;
				default:
					e.Handled = true;
					break;
			}
		}
	}
}
