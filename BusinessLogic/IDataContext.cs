using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IDataContext
    {
        DbSet<T> Set<T>() where T : class;
        Task SaveChangesAsync();
    }
}
