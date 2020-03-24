using BusinessLogic.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-MA2QV8N\\SQLEXPRESS;Database=JobSocialNetwork;Integrated Security=True");

            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}
