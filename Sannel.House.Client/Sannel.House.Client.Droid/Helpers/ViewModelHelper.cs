using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using Sannel.House.Client.Interfaces;
using System.Windows.Input;

namespace Sannel.House.Client.Droid.Helpers
{
	public class ViewModelHelper<TViewModel>
		where TViewModel : IBaseViewModel
	{
		private TViewModel vm;
		private Dictionary<String, Tuple<TextView, PropertyInfo>> textConnections = new Dictionary<string, Tuple<TextView, PropertyInfo>>();
		private Dictionary<String, Tuple<Button, PropertyInfo>> actionConnections = new Dictionary<string, Tuple<Button, PropertyInfo>>();
		private Dictionary<String, Tuple<View, PropertyInfo, bool>> visibilityConnections = new Dictionary<string, Tuple<View, PropertyInfo, bool>>();
		private List<String> ignoreChange = new List<String>();

		public ViewModelHelper(TViewModel vm)
		{
			this.vm = vm;
			vm.PropertyChanged += propertyChanged;
		}

		private void propertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (textConnections.ContainsKey(e.PropertyName))
			{
				if (!ignoreChange.Contains(e.PropertyName))
				{
					var tp = textConnections[e.PropertyName];
					tp.Item1.Text = tp.Item2.GetValue(vm).ToString();
				}
			}
			if (visibilityConnections.ContainsKey(e.PropertyName))
			{
				if (!ignoreChange.Contains(e.PropertyName))
				{
					var tp = visibilityConnections[e.PropertyName];
					bool? value = tp.Item2.GetValue(vm) as bool?;
					if (value.HasValue)
					{
						if (value.Value != tp.Item3)
						{
							tp.Item1.Visibility = ViewStates.Visible;
						}
						else
						{
							tp.Item1.Visibility = ViewStates.Gone;
						}
					}
				}
			}
		}

		public ViewModelHelper<TViewModel> BindText<TReturn>(Expression<Func<TViewModel, TReturn>> property, TextView view)
		{
			var name = property.GetMemberInfo().Name;

			var rp = vm.GetType().GetRuntimeProperty(name);

			textConnections[name] = new Tuple<TextView, PropertyInfo>(view, rp);

			view.AfterTextChanged += textViewAfterTextChanged;
			view.Tag = name;

			return this;
		}


		public ViewModelHelper<TViewModel> ConnectCommand<TReturn>(Expression<Func<TViewModel, TReturn>> property, Button button)
			where TReturn : ICommand
		{
			var mi = property.GetMemberInfo();

			var name = mi.Name;

			var rp = vm.GetType().GetRuntimeProperty(name);

			actionConnections[name] = new Tuple<Button, PropertyInfo>(button, rp);
			button.Tag = name;
			button.Click += button_click;

			return this;
		}

		public ViewModelHelper<TViewModel> BindVisible(Expression<Func<TViewModel,bool>> property, View view, bool isNot = false)
		{
			var mi = property.GetMemberInfo();
			var name = mi.Name;

			var rp = vm.GetType().GetRuntimeProperty(name);

			visibilityConnections[name] = new Tuple<View, PropertyInfo, bool>(view, rp, isNot);

			return this;
		}

		public void CleanUp()
		{
			foreach(var tp in textConnections)
			{
				tp.Value.Item1.AfterTextChanged -= textViewAfterTextChanged;
			}
			textConnections.Clear();
			foreach(var a in actionConnections)
			{
				a.Value.Item1.Click -= button_click;
			}
			actionConnections.Clear();
		}

		private void button_click(object sender, EventArgs e)
		{
			Button button = sender as Button;
			if(button != null)
			{
				String propName = button.Tag.ToString();
				if (actionConnections.ContainsKey(propName))
				{
					var tp = actionConnections[propName];
					var command = tp.Item2.GetValue(vm) as ICommand;
					if(command != null && command.CanExecute(null))
					{
						command.Execute(null);
					}
				}
			}
		}

		private void textViewAfterTextChanged(object sender, Android.Text.AfterTextChangedEventArgs e)
		{
			TextView tv = sender as TextView;
			if (tv != null)
			{
				String propName = tv.Tag.ToString();
				if (textConnections.ContainsKey(propName))
				{
					ignoreChange.Add(propName);
					textConnections[propName].Item2.SetValue(vm, tv.Text);
					ignoreChange.Remove(propName);
				}
			}
		}
	}
}