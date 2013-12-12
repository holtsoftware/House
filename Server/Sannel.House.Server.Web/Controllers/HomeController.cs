using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Sannel.House.Server.Data;
using Sannel.House.Server.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpPost = System.Web.Mvc.HttpPostAttribute;

namespace Sannel.House.Server.Web.Controllers
{
	public class HomeController : Controller
	{
		private EntityContext context;
		private UserManager<ApplicationUser> manager;

		public HomeController()
		{
			context = new EntityContext();
			manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
		}

		//
		// GET: /Home/
		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> RegisterUser([FromBody]AuthUser model)
		{
			if (ModelState.IsValid)
			{
				var user = new ApplicationUser
				{
					UserName = model.UserName,
					DisplayName = model.DisplayName,
					EmailAddress = model.EmailAddress
				};
				var results = await manager.CreateAsync(user, model.Password);

				if (results.Succeeded)
				{
					await SignInAsync(user, false);
					return Json(true);
				}
				else
				{
					return Json(results.Errors);
				}
			}

			return Json(false);
		}

		[HttpPost]
		public async Task<ActionResult> Login([FromBody]LoginUserModel model)
		{
			if(ModelState.IsValid)
			{
				var user = await manager.FindAsync(model.UserName, model.Password);
				if(user != null)
				{
					await SignInAsync(user, false);
					return Json(true);
				}
			}

			return Json(false);
		}


		#region Helpers
		// Used for XSRF protection when adding external logins
		private const string XsrfKey = "XsrfId";

		private IAuthenticationManager AuthenticationManager
		{
			get
			{
				return HttpContext.GetOwinContext().Authentication;
			}
		}

		private async Task SignInAsync(ApplicationUser user, bool isPersistent)
		{
			AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
			var identity = await manager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
			AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
		}

		private void AddErrors(IdentityResult result)
		{
			foreach (var error in result.Errors)
			{
				ModelState.AddModelError("", error);
			}
		}

		private bool HasPassword()
		{
			var user = manager.FindById(User.Identity.GetUserId());
			if (user != null)
			{
				return user.PasswordHash != null;
			}
			return false;
		}

		public enum ManageMessageId
		{
			ChangePasswordSuccess,
			SetPasswordSuccess,
			RemoveLoginSuccess,
			Error
		}

		private ActionResult RedirectToLocal(string returnUrl)
		{
			if (Url.IsLocalUrl(returnUrl))
			{
				return Redirect(returnUrl);
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}
		}

		private class ChallengeResult : HttpUnauthorizedResult
		{
			public ChallengeResult(string provider, string redirectUri)
				: this(provider, redirectUri, null)
			{
			}

			public ChallengeResult(string provider, string redirectUri, string userId)
			{
				LoginProvider = provider;
				RedirectUri = redirectUri;
				UserId = userId;
			}

			public string LoginProvider { get; set; }
			public string RedirectUri { get; set; }
			public string UserId { get; set; }

			public override void ExecuteResult(ControllerContext context)
			{
				var properties = new AuthenticationProperties() { RedirectUri = RedirectUri };
				if (UserId != null)
				{
					properties.Dictionary[XsrfKey] = UserId;
				}
				context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
			}
		}
		#endregion
	}
}