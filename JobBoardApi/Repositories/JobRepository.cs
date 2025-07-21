using JobBoardApi.Data;
using JobBoardApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JobBoardApi.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly AppDbContext _context;

        public JobRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Job>> GetAllAsync()
        {
            return await _context.Jobs.ToListAsync();
        }
        public async Task<Job?> GetByIdAsync(int id)
        {
            return await _context.Jobs.FindAsync(id);
        }
        public async Task AddAsync(Job job)
        {
            await _context.Jobs.AddAsync(job);
        }
        public async Task DeleteAsync(Job job)
        {
            _context.Jobs.Remove(job);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
