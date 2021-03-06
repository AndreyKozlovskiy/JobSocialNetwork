﻿using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Repositories.Contracts
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();
        Task AddAsync(T item);
        Task UpdateAsync(int itemId, T newItem);
        Task RemoveAsync(int itemId);
    }
}