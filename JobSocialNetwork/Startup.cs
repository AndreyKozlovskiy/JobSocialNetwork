using BusinessLogic;
using BusinessLogic.Models;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System.Linq;
using BusinessLogic.Repositories;

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
   options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
   sqlServerOptionsAction: sqlOptions =>
   {
       sqlOptions.EnableRetryOnFailure();
   }));
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

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
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
