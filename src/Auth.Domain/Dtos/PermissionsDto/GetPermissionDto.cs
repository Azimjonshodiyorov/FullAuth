using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Dtos.PermissionsDto
{
    public class GetPermissionDto
    {
        public long Id { get; set; }
        public string ActionName { get; set; }
    }
}
