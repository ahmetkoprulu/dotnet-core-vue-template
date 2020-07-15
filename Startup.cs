using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VueCliMiddleware;
using Web.Entity;

namespace vue_template
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<ApplicationDb>();
			services.AddControllers();
			services.AddSpaStaticFiles(o => o.RootPath = "ClientApp");
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseDeveloperExceptionPage();
			app.UseDefaultFiles();
			app.UseStaticFiles();
			app.UseSpaStaticFiles();

			app.UseWebSockets();

			app.UseEndpoints(e =>
			{
				e.MapControllers();
				if (env.IsDevelopment())
				{
					e.MapToVueCliProxy(
					"{*path}",
					new SpaOptions { SourcePath = "ClientApp" },
					npmScript: "serve",
					regex: "Compiled successfully",
					forceKill: true
					);
				}
			});

		}
	}
}
