using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Control.Data.Models
{
	public class StoredDevice
	{
		[Key]
		public Guid Id { get; set; } = Guid.NewGuid();
		public uint ShortId { get; set; }
		public String Name { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
	}
}
