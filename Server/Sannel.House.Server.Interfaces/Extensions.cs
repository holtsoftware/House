using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Server.Interfaces
{
	public static class Extensions
	{
		/// <summary>
		/// Copies the contents of <paramref name="source"/> to <paramref name="destination"/>
		/// The contents of Circuits is not copied.
		/// <paramref name="source"/> and <paramref name="destination"/> cannot be null and an ArgumentNullException will be thrown.
		/// </summary>
		/// <param name="source"></param>
		/// <param name="destination"></param>
		public static void CopyTo(this IRoom source, IRoom destination)
		{
			if(source == null)
			{
				throw new ArgumentNullException("source");
			}

			if(destination == null)
			{
				throw new ArgumentNullException("destination");
			}

			destination.RoomId = source.RoomId;
			destination.Name = source.Name;
			destination.Description = source.Description;
			destination.Order = source.Order;
			destination.Color = source.Color;
		}
	}
}
