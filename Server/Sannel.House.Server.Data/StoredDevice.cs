using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Server.Data
{
	public class StoredDevice
	{
		[Key]
		public Guid Id { get; set; }
		public uint ShortId { get; set; }
		[StringLength(256)]
		public String Name { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime UpdatedDate { get; set; }
	}
}
