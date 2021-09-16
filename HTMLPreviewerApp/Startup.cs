using HTMLPreviewerApp.Data;
using Microsoft.AspNetCore.Mvc;
using HTMLPreviewerApp.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using HTMLPreviewerApp.Infrastructure;
using HTMLPreviewerApp.Services.Conversions;
using HTMLPreviewerApp.Services.Samples;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HTMLPreviewerApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
            => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDbContext<PreviewerDbContext>(options => options
                    .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services
                .AddDefaultIdentity<User>(options =>
                {
                    options.Password.RequireNonAlphanumeric = false;
                })
                .AddEntityFrameworkStores<PreviewerDbContext>();

            services
                .AddControllersWithViews(options =>
                {
                    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
                });

            services
                .AddTransient<IConvert, Convert>()
                .AddTransient<ISamplesService, SamplesService>();

            services.AddRazorPages(options =>
            {
                options.Conventions.AddAreaPageRoute("Identity", "/Account/Register", "/Register");
                options.Conventions.AddAreaPageRoute("Identity", "/Account/Login", "/Login");
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.PrepareDatabase();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app
                .UseHttpsRedirection()
                .UseStaticFiles()
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                    {
                        endpoints.MapDefaultControllerRoute();
                        endpoints.MapRazorPages();
                    });
        }
    }
}
