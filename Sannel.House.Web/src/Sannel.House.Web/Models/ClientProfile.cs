using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#if CLIENT
namespace Sannel.House.Client.Models
#else
namespace Sannel.House.Web.Models
#endif
{
    public class ClientProfile
    {
		[JsonProperty(nameof(Name))]
		public String Name { get; set; }
		[JsonProperty(nameof(Roles))]
		public IEnumerable<String> Roles { get; set; }
	}
}
