using Auth.Domain.Entities.Auth.UserRoles;
using Auth.Domain.Entities.BaseEntities;
using Auth.Domain.Entities.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auth.Domain.Entities.Auth.Users
{
    [Table( "user", Schema = "auth_full")]
    public class User : AuditableBaseEntity<long>
    {
        [Column("first_name")]
        public string  FirstName { get; set; }
        [Column("last_name")]
        public string? LastName { get; set; }
        [Column("date_of_brith")]
        public DateTimeOffset DateOfBrith { get; set; }
        [Column("phone_number")] 
        public string PhoneNumber { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("is_bloked")]
        public bool IsBlocked { get; set; } = false;

        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
