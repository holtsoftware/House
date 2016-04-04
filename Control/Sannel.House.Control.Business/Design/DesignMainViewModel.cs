using Sannel.House.Control.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Control.Business.Design
{
	public class DesignMainViewModel : IMainViewModel
	{
		public string Date
		{
			get
			{
				return $"{DateTime.Now:d}";
			}

			set
			{
			}
		}

		public String DisplayTemperature
		{
			get
			{
				return $"{72.2}";
			}
			set
			{

			}
		}

		public string Time
		{
			get
			{
				return $"{DateTime.Now:t}";
			}

			set
			{
			}
		}

		public void Update()
		{
		}
	}
}
