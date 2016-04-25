using Sannel.House.Control.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Control.HttpHelpers
{
	public abstract class BasicAuthenticationRought : IRought
	{
		public abstract string Path
		{
			get;
		}

		public async Task RequestAsync(HttpRequest request, HttpResponse response)
		{
			if (request.Headers.ContainsKey("Authorization"))
			{
				var auth = request.Headers["Authorization"];
				var code = auth?.Replace("Basic ", "");
				var a = UTF8Encoding.ASCII.GetString(Convert.FromBase64String(code));
				var split = a.IndexOf(':');
				if(split > -1)
				{
					var username = a.Substring(0, split);
					var password = a.Substring(split + 1);

					if(await IsValidAsync(username, password))
					{
						response.Username = username;
						await AuthenticatedRequestAsync(request, response);
						return;
					}
				}
			}


			response.StatusCode = 401;
			response.Headers.Add("WWW-Authenticate", "Basic realm=\"Sannel Server\"");
		}

		public abstract Task<bool> IsValidAsync(String username, String password);

		public abstract Task AuthenticatedRequestAsync(HttpRequest request, HttpResponse response);
	}
}
