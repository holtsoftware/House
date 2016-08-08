using Sannel.House.Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Client.ViewModels
{
	public class ShellViewModel : IShellViewModel
	{
		public ShellViewModel()
		{

		}

		public string Test
		{
			get; set;
		} = "Test";
	}
}
