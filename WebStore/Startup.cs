﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebStore
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration Config) => Configuration = Config;
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseDefaultFiles();

            app.UseMvc(routes =>
           {
               routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
           });

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync(Configuration["CustomData"]);
            //});
        }
    }
}