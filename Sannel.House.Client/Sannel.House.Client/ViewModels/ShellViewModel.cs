using Sannel.House.Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Client.ViewModels
{
	public class ShellViewModel : BaseViewModel, IShellViewModel
	{
		public ShellViewModel()
		{

		}


		private bool isPaneOpen;
		/// <summary>
		/// Gets or sets the IsPaneOpen
		/// </summary>
		/// <value>
		/// The IsPaneOpen
		/// </value>
		public bool IsPaneOpen
		{
			get
			{
				return isPaneOpen;
			}
			set
			{
				Set(ref isPaneOpen, value);
			}
		}

	}
}
