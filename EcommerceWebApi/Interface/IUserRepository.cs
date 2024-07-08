using EcommerceWebApi.Dtos.User;
using EcommerceWebApi.Models;

namespace EcommerceWebApi.Interface
{
    public interface IUserRepository
    {
        public Task<List<User>> GetAllUsers();
        public Task<User?> GetById(Guid id);
        public Task<User> CreateUser(CreateUserDto userDto);
        public Task<User?> UpdateUser(Guid id, UpdateUserDto userDto);
        public Task<User?> DeleteUser(Guid id);
        public Task<User?> LoginUser(LoginUserDto loginUser);

    }
}
