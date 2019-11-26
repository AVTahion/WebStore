using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebStore.DAL.Context;
using WebStore.Data;
using WebStore.infrastucture.interfaces;
using WebStore.infrastucture.Services;

namespace WebStore
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration Config) => Configuration = Config;
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<WebStoreContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<WebStoreContextInitializer>();

            services.AddSingleton<IEmployeesData, InMemoryEmployeesData>();
            //services.AddScoped<IProductData, InMemoryProductData>();
            services.AddScoped<IProductData, SqlProductData>();
            services.AddSession();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, WebStoreContextInitializer db)
        {
            db.InitializeAsync().Wait();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }

            app.UseStaticFiles();
            app.UseDefaultFiles();
            app.UseSession();

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
