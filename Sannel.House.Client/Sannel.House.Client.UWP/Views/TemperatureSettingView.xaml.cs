using Sannel.House.Client.Interfaces;
using Sannel.House.Client.Models;
using Sannel.House.Client.UWP.Controls;
using Sannel.House.Client.UWP.Models;
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

namespace Sannel.House.Client.UWP.Views
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class TemperatureSettingView : BaseView
	{
		private ITemperatureSettingViewModel TempViewModel
		{
			get
			{
				return ViewModel as ITemperatureSettingViewModel;
			}
		}
		private List<TemperatureSection> sections = new List<TemperatureSection>();

		public TemperatureSettingView()
		{
			this.InitializeComponent();
			buildCalander();
		}

		private void buildCalander()
		{
			int start = (int)DayOfWeek.Sunday;
			int end = (int)DayOfWeek.Saturday;
			for (int i = start; i <= end; i++)
			{
				buildColumn(i);
			}
		}
		private Style tempHourStart;
		private Style tempHourEnd;

		private void buildColumn(int dayOfWeek)
		{
			int row = 0;
			var end = new DateTime(1, 1, 2, 0, 0, 0);
			for (DateTime dt = new DateTime(1, 1, 1, 0, 0, 0); dt < end; dt = dt.AddMinutes(30))
			{
				Border b = new Border();
				b.SetValue(Grid.ColumnProperty, dayOfWeek);
				b.SetValue(Grid.RowProperty, row);
				b.Tag = new BorderTag()
				{
					DayOfWeek = dayOfWeek,
					CellDateTime = dt
				};
				b.Tapped += Border_Tapped;

				if (dt.Minute == 0)
				{
					b.Style = tempHourStart ?? (tempHourStart = this.TryFindResource("TempHourStart") as Style);
					b.HorizontalAlignment = HorizontalAlignment.Stretch;
					b.VerticalAlignment = VerticalAlignment.Stretch;

					TextBlock tb = new TextBlock();
					b.Child = tb;
					tb.Text = dt.ToString("h t").ToLower();
				}
				else
				{
					b.Style = tempHourEnd ?? (tempHourEnd = this.TryFindResource("TempHourEnd") as Style);
					b.HorizontalAlignment = HorizontalAlignment.Stretch;
					b.VerticalAlignment = VerticalAlignment.Stretch;

				}
				Calander.Children.Add(b);

				row++;
			}
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			TempViewModel.DaySettings.CollectionChanged += daySettings_CollectionChanged;
			base.OnNavigatedTo(e);
		}

		protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
		{
			base.OnNavigatingFrom(e);
			TempViewModel.DaySettings.CollectionChanged -= daySettings_CollectionChanged;
		}
		private void daySettings_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			if (e.OldItems != null)
			{
				foreach (TemperatureSetting ts in e.OldItems)
				{
					removeSection(ts);
				}
			}
			if (e.NewItems != null)
			{
				foreach (TemperatureSetting ts in e.NewItems)
				{
					addDayTemperatureToWeek(ts);
				}
			}
		}

		private void removeSection(TemperatureSetting temperatureSetting)
		{
			for(int i = 0; i < sections.Count; i++)
			{
				if(sections[i].DataContext == temperatureSetting)
				{
					sections.RemoveAt(i);
					break;
				}
			}
		}

		private void addDayTemperatureToWeek(TemperatureSetting temperatureSetting)
		{
			TemperatureSection tempSection = new TemperatureSection();
			tempSection.DataContext = temperatureSetting;
			tempSection.SetValue(Grid.ColumnProperty, (int)temperatureSetting.DayOfWeek);

			int rowSpan = 0;
			int row = 0;
			var end = new DateTime(1, 1, 2, 0, 0, 0);
			for (DateTime dt = new DateTime(1, 1, 1, 0, 0, 0); dt <= end; dt = dt.AddMinutes(30))
			{
				if (temperatureSetting.StartTime == dt)
				{
					tempSection.SetValue(Grid.RowProperty, row);
				}
				if(temperatureSetting.StartTime < dt && temperatureSetting.EndTime >= dt)
				{
					rowSpan++;
				}
				row++;
			}

			tempSection.SetValue(Grid.RowSpanProperty, rowSpan);
			sections.Add(tempSection);
			Calander.Children.Add(tempSection);
		}

		private void Button_FocusDisengaged(Control sender, FocusDisengagedEventArgs args)
		{
		}

		private async void Flyout_Closed(object sender, object e)
		{

			Flyout flyout = (Flyout)sender;
			Button button = (Button)flyout.Target;

			TemperatureSetting ts = button.DataContext as TemperatureSetting;
			await TempViewModel.SaveTemperatureSettingAsync(ts);
		}

		private async void Border_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Border b = (Border)sender;
			var tag = b.Tag as BorderTag;
			TemperatureSetting ts = TempViewModel.CreateNewTemperatureSetting();
			EditControl.TemperatureViewModel = TempViewModel;
			EditControl.TemperatureSetting = ts;
			ts.StartTime = tag.CellDateTime;
			ts.EndTime = tag.CellDateTime;
			ts.IsTimeOnly = true;
			ts.DayOfWeek = (DayOfWeek)tag.DayOfWeek;
			var results = await EditControl.ShowAsync();
			if (results == ContentDialogResult.Primary)
			{
				await TempViewModel.SaveTemperatureSettingAsync(ts);
			}

			EditControl.DataContext = null;
		}
	}
}
