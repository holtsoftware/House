using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sannel.House.Web.Base.Models
{
	public struct Time
	{
		private ushort hour;
		private ushort minute;

		public Time(ushort hour, ushort minute)
		{
			if(hour > 24)
			{
				throw new ArgumentOutOfRangeException(nameof(hour));
			}

			if(minute > 60)
			{
				throw new ArgumentOutOfRangeException(nameof(minute));
			}

			this.hour = hour;
			this.minute = minute;
		}

		/// <summary>
		/// Gets the hour.
		/// </summary>
		/// <value>
		/// The hour.
		/// </value>
		public ushort Hour
		{
			get
			{
				return hour;
			}
		}

		/// <summary>
		/// Gets the minute.
		/// </summary>
		/// <value>
		/// The minute.
		/// </value>
		public ushort Minute
		{
			get
			{
				return minute;
			}
		}

		/// <summary>
		/// Performs an implicit conversion from <see cref="Time"/> to <see cref="System.Int64"/>.
		/// </summary>
		/// <param name="t">The t.</param>
		/// <returns>
		/// The result of the conversion.
		/// </returns>
		public static implicit operator ushort(Time t)
		{
			return (ushort)((t.hour << 8) | t.minute);
		}

		/// <summary>
		/// Performs an implicit conversion from <see cref="System.Int64"/> to <see cref="Time"/>.
		/// </summary>
		/// <param name="ticks">The ticks.</param>
		/// <returns>
		/// The result of the conversion.
		/// </returns>
		public static implicit operator Time(ushort ticks)
		{
			ushort h = (ushort)(ticks >> 8);
			ushort m = (ushort)(ticks & 0xFF);
			return new Time(h, m);
		}

		/// <summary>
		/// Performs an implicit conversion from <see cref="System.Int32"/> to <see cref="Time"/>.
		/// </summary>
		/// <param name="ticks">The ticks.</param>
		/// <returns>
		/// The result of the conversion.
		/// </returns>
		public static implicit operator Time(int ticks)
		{
			ushort h = (ushort)(ticks >> 8);
			ushort m = (ushort)(ticks & 0xFF);
			return new Time(h, m);
		}
	}
}
