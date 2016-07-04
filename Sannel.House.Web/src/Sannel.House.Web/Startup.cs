using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sannel.House.Web.Base.Interfaces;
using Sannel.House.Web.Data;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Sannel.House.Web.Base.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.DataProtection;

namespace Sannel.House.Web
{
	public class Startup
	{
		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
				.AddEnvironmentVariables();
			Configuration = builder.Build();
		}

		public IConfigurationRoot Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// Add framework services.
			services.AddEntityFramework();
			services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration["ConnectionString"]));
			services.AddMvc();
			services.AddMvcCore();
			services.AddIdentity<ApplicationUser, IdentityRole>(options =>
			{
				options.Cookies.ApplicationCookie.AuthenticationScheme = "ApplicationCookie";
				options.Cookies.ApplicationCookie.CookieName = "Authz";
				options.Password.RequireDigit = false;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireUppercase = false;
				options.Password.RequiredLength = 4;
			})
			.AddEntityFrameworkStores<DataContext>()
				.AddDefaultTokenProviders();
			services.AddAntiforgery();
			services.AddSingleton(Configuration);
			services.AddScoped<IDataContext, DataContext>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");

				// For more details on creating database during deployment see http://go.microsoft.com/fwlink/?LinkID=615859
				try
				{
					using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
						.CreateScope())
					{
						serviceScope.ServiceProvider.GetService<DataContext>()
							 .Database.Migrate();
					}
				}
				catch { }
			}
			app.UseStaticFiles();

			app.UseIdentity();
			// To configure external authentication please see http://go.microsoft.com/fwlink/?LinkID=532715

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
