using JobBoardApi.Data;
using JobBoardApi.Interfaces;
using JobBoardApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JobBoardApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<User?> GetByIdAsync(int id)
        {
            return await _appDbContext.Users.FindAsync(id);
        }
        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _appDbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _appDbContext.Users.ToListAsync();
        }

        public async Task AddAsync(User user)
        {
            await _appDbContext.Users.AddAsync(user);
        }

        public async Task SaveChangesAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }

     
    }
}
