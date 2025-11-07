using Microsoft.EntityFrameworkCore;
using System.Reflection;
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

        public List<GetUserDto> GetAll()
        {
            return _context.Users
                .Select(u => new GetUserDto
                {
                    Id = u.Id,
                    Username = u.Username,
                    Firstname = u.Firstname,
                    Lastname = u.Lastname,
                    PhoneNumber = u.PhoneNumber,
                    Role = u.Role,
                    CreatedAt = u.CreatedAt
                })
                .ToList();
        }


        public GetUserDto? GetById(int id)
        {
            return _context.Users
                .Where(u => u.Id == id)
                .Select(u => new GetUserDto
                {
                    Id = u.Id,
                    Username = u.Username,
                    Firstname = u.Firstname,
                    Lastname = u.Lastname,
                    PhoneNumber = u.PhoneNumber,
                    Role = u.Role,
                    CreatedAt = u.CreatedAt
                })
                .FirstOrDefault();
        }


        public GetUserSummaryDto? Login(string username, string password)
        {
            return _context.Users
                .Where(u => u.Username == username && u.Password == password)
                .Select(u => new GetUserSummaryDto()
                {
                    Id = u.Id,
                    Username = u.Username,
                    Fullname = u.Firstname + " " + u.Lastname,
                    Role = u.Role
                })
                .FirstOrDefault();
        }
        public bool UsernameExists(string username)
        {
            return _context.Users.Any(u => u.Username == username);
        }

        public GetUserSummaryDto? Register(CreateUserDto model)
        {
            var entity = new User
            {
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Username = model.Username,
                Password = model.Password,
                CreatedAt = DateTime.Now,
                Role = model.Role,
                PhoneNumber = model.PhoneNumber
            };
            _context.Users.Add(entity);
            _context.SaveChanges();

            return new GetUserSummaryDto()
            {
                Id = entity.Id,
                Username = entity.Username,
                Fullname = entity.Firstname + " " + entity.Lastname,
                Role = entity.Role
            };
        }

        public UpdateUserDto? GetUpdateUserDetailsById(int id)
        {
            return _context.Users
                .Where(u => u.Id == id)
                .Select(u => new UpdateUserDto()
                {
                    Id = u.Id,
                    Username = u.Username,
                    Firstname = u.Firstname,
                    Lastname = u.Lastname,
                    PhoneNumber = u.PhoneNumber,
                    Role = u.Role,
                    Password = u.Password
                })
                .FirstOrDefault();
        }

        public bool Update(int userId, UpdateUserDto model)
        {

            var user = _context.Users
                .FirstOrDefault(u => u.Id == userId);

            try
            {
                if (user is not null)
                {
                    user.Username = model.Username;
                    user.Password = model.Password;
                    user.Firstname = model.Firstname;
                    user.Lastname = model.Lastname;
                    user.PhoneNumber = model.PhoneNumber;
                    user.Role = model.Role;

                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }

        }

        public bool DeleteById(int userId)
        {
            var rowsAffected = _context.Users
                .Where(x => x.Id == userId)
                .ExecuteDelete();

            return rowsAffected > 0;
        }
    }


}
