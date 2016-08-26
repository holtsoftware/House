using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

#if LOGGING_SERVICE
namespace Sannel.House.Logging.Models
#else
namespace Sannel.House.Web.Base.Models
#endif
{
	public class ApplicationLogEntry
	{
		[Key]
		[JsonProperty(nameof(Id))]
		public Guid Id
		{
			get;
			set;
		}

		[JsonProperty(nameof(DeviceId))]
		public int? DeviceId
		{
			get;
			set;
		}

		[Required]
		[MaxLength(256)]
		[JsonProperty(nameof(ApplicationId))]
		public String ApplicationId
		{
			get;
			set;
		}

		[Required]
		[JsonProperty(nameof(Message))]
		public String Message
		{
			get;
			set;
		}

		[JsonProperty(nameof(Exception))]
		public String Exception
		{
			get;
			set;
		}

		[Required]
		[JsonProperty(nameof(EntryDateTime))]
		public DateTime EntryDateTime
		{
			get;
			set;
		}

#if LOGGING_SERVICE
		public bool Synced
		{
			get;
			set;
		} = false;
#endif
	}
}
