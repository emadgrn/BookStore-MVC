using UI.Models.Entities.Enums;

namespace UI.Models
{
    public class OnlineUser
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public RoleEnum Role { get; set; }
    }
}
