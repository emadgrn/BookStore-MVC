using UI.Models.Entities.Enums;

namespace UI.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? PhoneNumber { get; set; }
        public RoleEnum Role { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
