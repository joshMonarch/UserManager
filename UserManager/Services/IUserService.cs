using UserManager.Dtos;

namespace UserManager.Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsersAsync();
        Task<UserDto?> GetUserByIdAsync(int id);
        Task<UserDto> CreateUserAsync(CreateUserDto user);
        Task<UserDto?> UpdateUserByIdAsync(int id, UpdateUserDto user);
        Task<bool> DeleteUserByIdAsync(int id);
    }
}