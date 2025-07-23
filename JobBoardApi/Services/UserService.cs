using AutoMapper;
using JobBoardApi.DTOs;
using JobBoardApi.Interfaces;
using JobBoardApi.Models;
using Microsoft.AspNetCore.Identity;

namespace JobBoardApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher,IMapper mapper)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);    
        }

        public async Task<UserDto?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return null;
            return user == null ? null : _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> RegisterUserAsync(CreateUserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            user.Role = string.IsNullOrEmpty(dto.Role) ? "User" : dto.Role;
            user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
            return _mapper.Map<UserDto>(user);
        }
    }

}
