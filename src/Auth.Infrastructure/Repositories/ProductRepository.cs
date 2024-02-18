using Auth.Domain.Entities.Products;
using Auth.Infrastructure.DbContexts;
using Auth.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Repositories
{
    public class ProductRepository : RepositoryBase<Product, long>, IProductRepository
    {
        public ProductRepository(AuthDbContext dbContext) : base(dbContext)
        {
        }
    }
}
