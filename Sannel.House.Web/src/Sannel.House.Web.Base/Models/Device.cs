﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

#if THERMOSTAT
namespace Sannel.House.Thermostat.Base.Models
#else
namespace Sannel.House.Web.Base.Models
#endif
{
	/// <summary>
	/// Represents a device using the platform
	/// </summary>
	public class Device
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
#if !THERMOSTAT
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
#endif
		[Key]
		[JsonProperty("Id")]
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		[MaxLength(256)]
		[Required]
		[JsonProperty("Name")]
		public String Name { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>
		/// The description.
		/// </value>
		[MaxLength(2000)]
		[Required]
		[JsonProperty("Description")]
		public String Description { get; set; }


		/// <summary>
		/// Gets or sets the display order.
		/// </summary>
		/// <value>
		/// The display order.
		/// </value>
		[JsonProperty("DisplayOrder")]
		public int DisplayOrder { get; set; }

		/// <summary>
		/// Gets or sets the date created.
		/// </summary>
		/// <value>
		/// The date created.
		/// </value>
		[JsonProperty("DateCreated")]
		public DateTimeOffset DateCreated { get; set; }

		/// <summary>
		/// Gets or sets if this device is readonly
		/// </summary>
		[JsonProperty("IsReadOnly")]
		public bool IsReadOnly { get; set; }
	}
}
