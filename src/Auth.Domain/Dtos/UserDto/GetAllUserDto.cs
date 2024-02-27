using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Dtos.UserDto
{
    public class GetAllUserDto
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset DateOfBrith { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
