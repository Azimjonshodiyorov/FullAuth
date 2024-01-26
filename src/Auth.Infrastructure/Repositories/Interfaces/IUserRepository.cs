using Auth.Domain.Entities.Auth.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User , long>
    {
    }
}
