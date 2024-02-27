using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Auth.Domain.Dtos.UserDto
{
    public class DeleteUserDto
    {
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z]).{8,}$", ErrorMessage ="Invalid password")]
        [Compare("ConfirmPassword", ErrorMessage ="Password do  not match")]
        public string Password { get; set; }
        [JsonPropertyName("confirm_password")]
        public string ConfirmPassword { get; set; }
    }
}
