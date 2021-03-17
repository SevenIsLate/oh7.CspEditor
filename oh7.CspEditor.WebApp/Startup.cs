using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using oh7.CspEditor.Models;

namespace oh7.CspEditor.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddRoles<IdentityRole>();

            services.AddRazorPages();

            services.AddRouting(options => options.LowercaseUrls = true);

            // Set alternative start page
            //services.AddMvc().AddRazorPagesOptions(options => options.Conventions.AddPageRoute("/Project/Index", ""));
            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
            
            // If using Kestrel:
            //services.Configure<KestrelServerOptions>(options => options.AllowSynchronousIO = true);

            // If using IIS:
            services.Configure<IISServerOptions>(options => options.AllowSynchronousIO = true);

            services.Configure<AppSettings>(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapRazorPages());
        }
    }
}