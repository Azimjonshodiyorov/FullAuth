using Auth.Domain.Entities.BaseEntities;
using Auth.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Repositories
{
    public class RepositoryBase<T, TId> : IRepositoryBase<T, TId> , IAsyncEnumerable<T>
    where T : BaseEntity<TId>
    {
        private readonly DbContext dbContext;

        public RepositoryBase(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Type ElementType
        {
            get => this.AsQueryable<T>().ElementType;
        }


        public Expression Expression
        {
            get => this.AsQueryable<T>().Expression;
        }

        public IQueryProvider Provider
        {
            get => this.AsQueryable<T>().Provider;
        }

        public async Task<T> AddAsync(T entity)
        {
            var result = await this.dbContext.Set<T>()
                .AddAsync(entity);
            return result.Entity;

        }

        public async Task AddRangeAsync(params T[] entities)
        {
              await this.dbContext.Set<T>()
                .AddRangeAsync(entities);
        }

        public IQueryable<T> GetAllAsQueryable(bool asNoTracking = false)
        {
            if(asNoTracking)
            {
                return this.dbContext
                    .Set<T>()
                    .AsNoTracking();
            }
            return this.dbContext.Set<T>();
        }

        public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return this.dbContext.Set<T>().GetAsyncEnumerator(cancellationToken);
        }

        public async Task<T?> GetByIdAsync(TId id, bool asNoTracking = false)
        {
            return await this.GetAllAsQueryable(asNoTracking)
                .FirstOrDefaultAsync(x => x.Id!.Equals(id));
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.GetAllAsQueryable()
                .GetEnumerator();
        }

        public async Task<T> RemoveAsync(T entity)
        {
            var result =  this.dbContext.Set<T>().Remove(entity);
            return result.Entity;
        }

        public async Task RemoveRangeAsync(params T[] entity)
        {
             this.dbContext.Set<T>().RemoveRange(entity);;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var result =  this.dbContext.Set<T>().Update(entity);

            return result.Entity;
        }

        public async Task UpdateRangeAsync(params T[] entities)
        {
           this.dbContext.Set<T>().UpdateRange(entities);
            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
