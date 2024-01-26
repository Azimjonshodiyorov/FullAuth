
namespace Auth.Domain.Dtos
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTimeOffset DateOfBrith { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
