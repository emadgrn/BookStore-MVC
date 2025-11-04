using Microsoft.EntityFrameworkCore;
using UI.Contracts.Repositories;
using UI.Models.DTOs.User;
using UI.Models.Entities;
using UI.Models.Entities.Enums;

namespace UI.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Create(CreateUserDto model)
        {
            var entity = new User()
            {
                Username = model.Username,
                Password = model.Password,
                PhoneNumber = model.PhoneNumber,
                Role = model.Role,
                CreatedAt = DateTime.Now
            };
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public List<GetUserDto> GetAll()
        {
            return _context.Users
                .Select(u => new GetUserDto
                {
                    Id = u.Id,
                    Username = u.Username,
                    PhoneNumber = u.PhoneNumber,
                    Role = u.Role,
                    CreatedAt = u.CreatedAt
                })
                .ToList();
        }
    }


}
