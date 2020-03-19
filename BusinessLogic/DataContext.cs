using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class DataContext:IDataContext
    {
        private readonly ApplicationContext appContext;

        public DataContext(ApplicationContext appDbContext)
        {
            appContext = appDbContext;
        }

        public Task SaveChangesAsync() => appContext.SaveChangesAsync();

        public DbSet<T> Set<T>() where T : class => appContext.Set<T>();
    }
}
