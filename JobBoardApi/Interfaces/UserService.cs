using JobBoardApi.DTOs;

namespace JobBoardApi.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto?> GetUserByIdAsync(int id);
        Task<UserDto> RegisterUserAsync(CreateUserDto dto);
    }

}
