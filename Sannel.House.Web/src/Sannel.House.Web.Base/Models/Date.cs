using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sannel.House.Web.Base.Models
{
	public struct Date 
	{
		private DateTime date;

		public Date(int day, int month, int year)
		{
			date = new DateTime(year, month, day);
		}

		/// <summary>
		/// Gets or sets the day.
		/// </summary>
		/// <value>
		/// The day.
		/// </value>
		public int Day
		{
			get
			{
				return date.Day;
			}
			set
			{
				date = new DateTime(date.Year, date.Month, value);
			}
		}

		/// <summary>
		/// Gets or sets the month.
		/// </summary>
		/// <value>
		/// The month.
		/// </value>
		public int Month
		{
			get
			{
				return date.Month;
			}
			set
			{
				date = new DateTime(date.Year, value, date.Day);
			}
		}

		/// <summary>
		/// Gets or sets the year.
		/// </summary>
		/// <value>
		/// The year.
		/// </value>
		public int Year
		{
			get
			{
				return date.Year;
			}
			set
			{
				date = new DateTime(value, date.Month, date.Day);
			}
		}

		/// <summary>
		/// Performs an implicit conversion from <see cref="Date"/> to <see cref="System.Int64"/>.
		/// </summary>
		/// <param name="d">The d.</param>
		/// <returns>
		/// The result of the conversion.
		/// </returns>
		public static implicit operator long(Date d)
		{
			return d.date.Ticks;
		}

		/// <summary>
		/// Performs an implicit conversion from <see cref="System.Int64"/> to <see cref="Date"/>.
		/// </summary>
		/// <param name="ticks">The ticks.</param>
		/// <returns>
		/// The result of the conversion.
		/// </returns>
		public static implicit operator Date(long ticks)
		{
			var dt = new DateTime(ticks);
			return new Date(dt.Day, dt.Month, dt.Year);
		}

	}
}
