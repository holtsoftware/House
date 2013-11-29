using Sannel.House.Server.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sannel.House.Server.Web.Controllers
{
	public class AuthenticationController : ApiController
	{
		public bool RegisterUser([FromBody]RegisterUser user)
		{
			if(ModelState.IsValid)
			{

			}

			return false;
		}
	}
}