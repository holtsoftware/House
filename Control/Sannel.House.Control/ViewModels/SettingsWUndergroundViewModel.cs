using Sannel.House.Control.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Control.ViewModels
{
	public class SettingsWUndergroundViewModel : SubViewModel
	{
		protected override void OnInitialize()
		{
			base.OnInitialize();
			wundergroundApiKey = AppSettings.Current.WUndergroundApiKey;
			wundergroundState = AppSettings.Current.WUndergroundState;
			wundergroundCity = AppSettings.Current.WUndergroundCity;
		}

		private String wundergroundApiKey;

		public String WUndergroundApiKey
		{
			get { return wundergroundApiKey; }
			set
			{
				AppSettings.Current.WUndergroundApiKey = value;
				Set(ref wundergroundApiKey, value);
			}
		}

		private String wundergroundState;

		public String WUndergroundState
		{
			get { return wundergroundState; }
			set
			{
				AppSettings.Current.WUndergroundState = value;
				Set(ref wundergroundState, value);
			}
		}

		private String wundergroundCity;

		public String WUndergroundCity
		{
			get
			{
				return wundergroundCity;
			}
			set
			{
				AppSettings.Current.WUndergroundCity = value;
				Set(ref wundergroundCity, value);
			}
		}
	}
}
