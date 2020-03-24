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
            services.AddSignalR();
            services.AddTransient(typeof(IUserRepository), typeof(UserRepository));
            services.AddTransient(typeof(IResumeRepository), typeof(ResumeRepository));
            services.AddTransient(typeof(IVacancyRepository), typeof(VacancyRepository));
            services.AddTransient(typeof(ISkillRepository), typeof(SkillRepository));
            services.AddTransient(typeof(IUserService), typeof(UserService));
            services.AddTransient(typeof(IVacancyService), typeof(VacancyService));
            services.AddTransient(typeof(ISkillService), typeof(SkillService));
            services.AddTransient(typeof(IResumeService), typeof(ResumeService));
            services.AddTransient<ApplicationService>();
            services.AddMvcCore();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
            }
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                            name: "default",
                            pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
