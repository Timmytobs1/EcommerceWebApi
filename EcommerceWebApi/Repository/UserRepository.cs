using EcommerceWebApi.Data;
using EcommerceWebApi.Dtos.User;
using EcommerceWebApi.Interface;
using EcommerceWebApi.Mappers;
using EcommerceWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User> CreateUser(CreateUserDto userDto)
        {
            var userModel = userDto.ToUserModel();
            await _context.Users.AddAsync(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public async Task<User?> DeleteUser(Guid id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return null;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public Task<User?> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetById(Guid id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public Task<User?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> LoginUser(LoginUserDto loginUser)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == loginUser.Email && x.Password == loginUser.Password);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<User?> UpdateUser(Guid id, UpdateUserDto userDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return null;
            }

            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.Email = userDto.Email;
            user.PhoneNumber = userDto.PhoneNumber;
            user.Password = userDto.Password;

            await _context.SaveChangesAsync();
            return user;

        }

    
    }
}
