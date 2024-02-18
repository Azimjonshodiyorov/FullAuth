using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Dtos.UserRoleDto
{
    public class PostUserRoleDto
    {
        public long UserId { get; set; }
        public string RoleId { get; set; }
    }
}
