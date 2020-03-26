using BusinessLogic.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using BusinessLogic.Repositories;
using BusinessLogic.Services.Contracts;
using BusinessLogic.Repositories.Contracts;
using BusinessLogic.Contexts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace JobSocialNetwork
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

            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer("Server=DESKTOP-MA2QV8N\\SQLEXPRESS;Database=JobSocialNetwork;Integrated Security=True"));
            services.AddTransient<IDataContext, DataContext>();
            
            services.AddTransient(typeof(IUserRepository), typeof(UserRepository));
            services.AddTransient(typeof(IResumeRepository), typeof(ResumeRepository));
            services.AddTransient(typeof(IVacancyRepository), typeof(VacancyRepository));
            services.AddTransient(typeof(ISkillRepository), typeof(SkillRepository));
            services.AddTransient(typeof(IUserService), typeof(UserService));
            services.AddTransient(typeof(IVacancyService), typeof(VacancyService));
            services.AddTransient(typeof(ISkillService), typeof(SkillService));
            services.AddTransient(typeof(IResumeService), typeof(ResumeService));
            services.AddTransient<ApplicationService>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("/Account/Login");
                });
            services.AddSignalR();
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                            name: "default",
                            pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
