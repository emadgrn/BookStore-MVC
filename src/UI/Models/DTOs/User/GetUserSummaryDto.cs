using UI.Models.Entities.Enums;

namespace UI.Models.DTOs.User
{
    public class GetUserSummaryDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public RoleEnum Role { get; set; }
    }
}
