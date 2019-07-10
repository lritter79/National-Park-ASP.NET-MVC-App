using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Capstone.Web.Models;
using Capstone.Web.DAL;


namespace Capstone.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });



            string connectionString = Configuration.GetConnectionString("Default");

<<<<<<< HEAD
            //services.AddTransient<NationalParkSqlDAO>();
            //services.AddTransient<WeatherSqlDAO>();
            //services.AddTransient<SurveySqlDAO>();

            services.AddScoped<INationalParkDAO, NationalParkSqlDAO>(j => new NationalParkSqlDAO(connectionString));
            services.AddScoped<ISurveyDAO, SurveySqlDAO>(j => new SurveySqlDAO(connectionString));
            services.AddScoped<IWeatherDAO, WeatherSqlDAO>(j => new WeatherSqlDAO(connectionString));

=======
            services.AddTransient<INationalParkDAO>(d => new NationalParkSqlDAO(connectionString));
            
>>>>>>> 26d4e6a8aecccbcb2e282fb2bde2dc7dfcbdc28c

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
