using Microsoft.AspNetCore.Identity;
using Sannel.House.Web.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Sannel.House.Web.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<String> GetNameAsync(this UserManager<ApplicationUser> um, ClaimsPrincipal user)
        {
            var auser = await um.GetUserAsync(user);
            return auser.Name;
        }
    }
}
