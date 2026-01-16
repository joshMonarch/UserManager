using UserManager.Dtos;
using UserManager.Models;
using UserManager.Repositories;

namespace UserManager.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> CreateUserAsync(CreateUserDto user)
        {
            var newUser = new User
            {
                Fullname = user.Fullname,
                Age = user.Age,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role
            };
            var createdUser = await _userRepository.CreateAsync(newUser);
            return new UserDto(
                createdUser.Id,
                createdUser.Fullname,
                createdUser.Age,
                createdUser.Email,
                user.Password,
                createdUser.Role,
                createdUser.CreatedAt,
                createdUser.UpdatedAt
            );
        }

        public async Task<bool> DeleteUserByIdAsync(int id)
        {
            return await _userRepository.DeleteAsync(id);
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.ConvertAll(user => new UserDto(
                user.Id,
                user.Fullname,
                user.Age,
                user.Email,
                user.Password,
                user.Role,
                user.CreatedAt,
                user.UpdatedAt
            ));
        }

        public async Task<UserDto?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user is null) return null;

            return new UserDto(
                user.Id,
                user.Fullname,
                user.Age,
                user.Email,
                user.Password,
                user.Role,
                user.CreatedAt,
                user.UpdatedAt
            );
        }

        public async Task<UserDto?> UpdateUserByIdAsync(int id, UpdateUserDto user)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser is null) return null;

            existingUser.Fullname = user.Fullname ?? existingUser.Fullname;
            existingUser.Age = user.Age ?? existingUser.Age;
            existingUser.Email = user.Email ?? existingUser.Email;
            if (user.Password is not null)
                existingUser.Password = user.Password;

            var updatedUser = await _userRepository.UpdateAsync(existingUser);
            if (updatedUser is null) return null;

            return new UserDto(
                updatedUser.Id,
                updatedUser.Fullname,
                updatedUser.Age,
                updatedUser.Email,
                updatedUser.Password,
                updatedUser.Role,
                updatedUser.CreatedAt,
                updatedUser.UpdatedAt
            );
        }
    }
}