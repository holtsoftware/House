using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sannel.House.Client.Models
{
	public class AsyncRelayCommand : ICommand
	{
		public AsyncRelayCommand(Func<Object, Task> command)
		{
			if(command == null)
			{
				throw new ArgumentNullException(nameof(command));
			}
			this.command = command;
		}

		private Func<Object, Task> command;

		private bool isEnabled = true;
		public bool IsEnabled
		{
			get
			{
				return isEnabled;
			}
			set
			{
				isEnabled = value;
				CanExecuteChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return IsEnabled;
		}

		public async void Execute(object parameter)
		{
			await ExecuteAsync(parameter);
		}

		public Task ExecuteAsync(object parameter)
		{
			return command(parameter);
		}
	}
}
