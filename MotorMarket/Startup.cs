using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MotorMarket.AppDbContext;
using AutoMapper;
using MotorMarket.MappingProfiles;

namespace MotorMarket
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
            services.AddControllersWithViews();
            //services.AddRazorPages();
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddDbContext<MgaleriDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddDefaultUI()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<MgaleriDbContext>();
            services.AddAuthorization(options =>
            {

                //options.AddPolicy("Admin",
                //    authBuilder =>
                //    {
                //        authBuilder.RequireRole("Admin");
                //    });

            });
            services.AddRazorPages();
            services.AddCloudscribePagination();

        }   


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
       
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                //endpoints.MapControllerRoute(
                //    "ByYearMonth", "main/motors/{year:int:length(4)}/{month:int:range(1,12)}", 
                //    new {controller="main", action="ByYearMonth"}
                //    );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Motorsiklet}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
