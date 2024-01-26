using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Repositories.Interfaces
{
    public interface IRepositoryBase<T , in TId> : IQueryable<T>
    {
        IQueryable<T> GetAllAsQueryable(bool asNoTracking = false);
        Task<T?> GetByIdAsync(TId id, bool asNoTracking = false);
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(params T[] entities);
        Task<T> UpdateAsync(T entity);
        Task UpdateRangeAsync(params T[] entities);
        Task<T> RemoveAsync(T entity);
        Task RemoveRangeAsync(params T[] entity);
    }
}
