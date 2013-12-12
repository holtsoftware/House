using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Sannel.House.Server.Data;
using Sannel.House.Server.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using System.Web.UI;
using Microsoft.Owin.Security;

namespace Sannel.House.Server.Web.Controllers
{
	public class AuthenticationController : ApiController
	{
		private EntityContext context;
		private UserManager<ApplicationUser> manager;

		public AuthenticationController()
		{
			context = new EntityContext();
			manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			manager.Dispose();
		}

		

		[Authorize]
		public AuthUser GetUserInfo()
		{
			String userId = HttpContext.Current.User.Identity.GetUserId();
			var user = context.Users.FirstOrDefault(i => i.Id == userId);
			if(user != null)
			{
				AuthUser auth = new AuthUser();
				auth.UserName = user.UserName;
				auth.DisplayName = user.DisplayName;
				auth.EmailAddress = user.EmailAddress;
				auth.IsAllowed = manager.IsInRole(user.Id, "Home");
				auth.IsAdmin = manager.IsInRole(user.Id, "Admin");

				return auth;
			}

			return null;
		}

		private IAuthenticationManager AuthenticationManager
		{
			get
			{
				return Request.GetOwinContext().Authentication;
			}
		}

		private async Task SignInAsync(ApplicationUser user, bool isPersistent)
		{
			
			AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
			var identity = await manager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
			AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
		}

		public bool CheckUsername(String id)
		{
			var hasLogin = context.Users.FirstOrDefault(i => i.UserName == id);

			if(hasLogin != null)
			{
				return true;
			}

			return false;
		}
	}
}