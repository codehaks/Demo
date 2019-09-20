using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Portal.Identity;
using Portal.Persistance;

namespace Portal.Web
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PortalDbContext>(options =>
            {
                //options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection"));
                options.UseSqlite("Data Source=portal.sqlite");
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
            });

            services.AddDefaultIdentity<ApplicationUser>(
                options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<PortalDbContext>();

            services.AddRazorPages();
            services.AddControllers();
            //services.AddSignalR();
            //services.AddAutoMapper(typeof(Application.Playing.HandMapper).GetTypeInfo().Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();                
                endpoints.MapControllers();
            });
        }
    }
}
