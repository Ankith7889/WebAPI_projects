using JobBoardApi.DTOs;
using JobBoardApi.Interfaces;
using JobBoardApi.Models;

namespace JobBoardApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(u => new UserDto
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email,
                Role = u.Role
            });
        }

        public async Task<UserDto?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role
            };
        }

        public async Task<UserDto> RegisterUserAsync(CreateUserDto dto)
        {
            // Simulate hash (we’ll fix this in auth step)
            var hash = "HASHED_" + dto.Password;

            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = hash
            };

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role
            };
        }
    }

}
