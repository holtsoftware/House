using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Sannel.House.Web.Base.Models;
using Sannel.House.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Sannel.House.Web.Extensions;

namespace Sannel.House.Web.Controllers
{
	[Authorize]
	public class AccountController : Controller
	{
		private readonly UserManager<ApplicationUser> userManager;
		private readonly SignInManager<ApplicationUser> signInManager;
		private readonly RoleManager<IdentityRole> roleManager;
		public AccountController(
			UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager,
			RoleManager<IdentityRole> roleManager)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
			this.roleManager = roleManager;
		}

		//
		// GET: /Account/Login
		[HttpGet]
		[AllowAnonymous]
		public IActionResult Login(string returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;

			return View();
		}

		//
		// POST: /Account/Login
		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;
			if (ModelState.IsValid)
			{
				var results = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
				if (results.Succeeded)
				{
					return RedirectToLocal(returnUrl);
				}
				else
				{
					ModelState.AddModelError(string.Empty, "Invalid login attempt.");
					return View(model);
				}
			}

			return View(model);
		}

		/// <summary>
		/// Logins from device.
		/// System.NET.HttpClient seams to be able to access the cookie set from this method easyer not sure why. Probably the lack of redirect?
		/// </summary>
		/// <param name="model">The model.</param>
		/// <returns></returns>
		[HttpPost]
		[AllowAnonymous]
		public async Task<JsonResult> LoginFromDevice(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				var results = await signInManager.PasswordSignInAsync(model.Email, model.Password, true, false);
				if (results.Succeeded)
				{
					var user = await userManager.FindByNameAsync(model.Email);
					return Json(new
					{
						Success = true,
						Name = user.Name
					});
				}
			}

			return Json(new
			{
				Success = false,
				Name = (String)null
			});
		}

		[HttpGet]
		public IActionResult AccessDenied(String returnUrl = null)
		{
			return View(model: returnUrl);
		}

		//
		// GET: /Account/Register
		[HttpGet]
		[AllowAnonymous]
		public IActionResult Register(string returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;
			return View();
		}

		//
		// POST: /Account/Register
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;
			if (ModelState.IsValid)
			{
				var user = new ApplicationUser { UserName = model.Email, Email = model.Email, Name = model.Name };
				var result = await userManager.CreateAsync(user, model.Password);
				if (result.Succeeded)
				{
					// For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=532713
					// Send an email with this link
					//var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
					//var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
					//await _emailSender.SendEmailAsync(model.Email, "Confirm your account",
					//    "Please confirm your account by clicking this link: <a href=\"" + callbackUrl + "\">link</a>");
					await signInManager.SignInAsync(user, isPersistent: false);
					return RedirectToLocal(returnUrl);
				}
				AddErrors(result);
			}

			// If we got this far, something failed, redisplay form
			return View(model);
		}

		//
		// POST: /Account/LogOff
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> LogOff()
		{
			await signInManager.SignOutAsync();
			return RedirectToAction(nameof(HomeController.Index), "Home");
		}

		[HttpGet]
		public async Task<JsonResult> GetRoles()
		{
			var user = await userManager.GetUserAsync(User);

			var roles = await userManager.GetRolesAsync(user);

			return Json(roles);
		}

		[HttpGet]
		public async Task<JsonResult> GetProfile()
		{
			var user = await userManager.GetUserAsync(User);

			var roles = await userManager.GetRolesAsync(user);

			return Json(new ClientProfile
			{
				Name = user.Name,
				Roles = roles
			});
		}

		private IActionResult RedirectToLocal(string returnUrl)
		{
			if (Url.IsLocalUrl(returnUrl))
			{
				return Redirect(returnUrl);
			}
			else
			{
				return RedirectToAction(nameof(HomeController.Index), "Home");
			}
		}

		private void AddErrors(IdentityResult result)
		{
			foreach (var error in result.Errors)
			{
				ModelState.AddModelError(string.Empty, error.Description);
			}
		}
	}
}
