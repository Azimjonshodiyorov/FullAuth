using Auth.Infrastructure.DbContexts;
using Auth.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace Auth.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork , IDisposable
    {
        private readonly AuthDbContext authDbContext;

        public UnitOfWork(AuthDbContext authDbContext)
        {
            this.authDbContext = authDbContext;
        }

        public IUserRepository Users { get; private set; }

        public IProductRepository Products { get; private set; }

        public IRefreshTokenRepository RefreshTokens { get; private set; }

        public IRoleRepsoitory Roles { get; private set; }

        public IDbTransaction BeginTransaction()
        {
            var transaction = authDbContext.Database.BeginTransaction();
            return transaction.GetDbTransaction();
        }

        public void Dispose()
        {
            ((IDisposable)authDbContext).Dispose();
        }

        public void SaveChanges()
        {
            authDbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await authDbContext.SaveChangesAsync();
        }
    }
}
