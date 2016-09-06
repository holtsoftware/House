using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.ServerSDK
{
	public sealed class TemperatureEntryResult
	{
		public TemperatureEntryResult(TemperatureEntryStatus status, ITemperatureEntry entry, Guid id)
		{
			Status = status;
			Entry = entry;
			Id = id;
		}
		public TemperatureEntryStatus Status { get; set; }

		public ITemperatureEntry Entry { get; set; }

		public Guid Id { get; set; }
	}
}
