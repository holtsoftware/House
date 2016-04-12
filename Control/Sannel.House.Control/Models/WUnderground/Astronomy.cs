using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Control.Models.WUnderground
{
	public class Astronomy
	{
		public Response response { get; set; }
		public MoonPhase moon_phase { get; set; }

		public class Features
		{
			public int astronomy { get; set; }
		}

		public class Response
		{
			public string version { get; set; }
			public string termsofService { get; set; }
			public Features features { get; set; }
		}

		public class CurrentTime
		{
			public string hour { get; set; }
			public string minute { get; set; }
		}

		public class Sunrise
		{
			public string hour { get; set; }
			public string minute { get; set; }
		}

		public class Sunset
		{
			public string hour { get; set; }
			public string minute { get; set; }
		}

		public class MoonPhase
		{
			public string percentIlluminated { get; set; }
			public string ageOfMoon { get; set; }
			public CurrentTime current_time { get; set; }
			public Sunrise sunrise { get; set; }
			public Sunset sunset { get; set; }
		}
	}
}
