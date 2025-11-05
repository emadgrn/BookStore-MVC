using UI.Models.Entities.Enums;

namespace UI.Models.ViewModels
{
    public class RegisterViewModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? PhoneNumber { get; set; }
        public RoleEnum Role { get; set; }
    }
}
