﻿using Sannel.House.Web.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

#if LOGGING_SERVICE || LOGGING_SDK
namespace Sannel.House.Logging.Models
#else
namespace Sannel.House.Web.Base.Models
#endif
{
	public class ApplicationLogEntry
	{
#if !LOGGING_SDK
		[Key]
		public Guid Id
		{
			get;
			set;
		}
#endif

		public int? DeviceId
		{
			get;
			set;
		}

		[Required]
		[MaxLength(256)]
		public String ApplicationId
		{
			get;
			set;
		}

		[Required]
		public String Message
		{
			get;
			set;
		}

		public String Exception
		{
			get;
			set;
		}
#if !LOGGING_SDK
		[Required]
		public DateTimeOffset CreatedDate
		{
			get;
			set;
		}
#endif

#if LOGGING_SERVICE
		public bool Synced
		{
			get;
			set;
		} = false;
#endif
	}
}
