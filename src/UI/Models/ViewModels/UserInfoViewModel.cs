using UI.Models.Entities.Enums;

namespace UI.Models.ViewModels
{
    public class UserInfoViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string? PhoneNumber { get; set; }
        public RoleEnum Role { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
