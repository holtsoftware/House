using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Client.UWP.Models
{
	public class TimeItem
	{
		public String Display
		{
			get
			{
				return Value.ToString("h:mm t").ToLower();
			}
		}
		public DateTime Value { get; set; }

		public override bool Equals(object obj)
		{
			if(obj is TimeItem)
			{
				return Value == ((TimeItem)obj).Value;
			}
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return Value.GetHashCode();
		}
	}
}
