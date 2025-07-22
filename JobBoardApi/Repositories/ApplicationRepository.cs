using JobBoardApi.Data;
using JobBoardApi.Interfaces;
using JobBoardApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JobBoardApi.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly AppDbContext _context;
        public ApplicationRepository(AppDbContext appDbContext) 
        {
            _context = appDbContext;
        }
        public async Task AddAsync(JobApplication application)
        {
             await _context.AddAsync(application);
        }

        public async Task<IEnumerable<JobApplication>> GetByJobIdAsync(int jobId)
        {
            return await _context.Applications
                .Where(a => a.JobId == jobId)
                .Include(a => a.Job)      
                .Include(a => a.User)     
                .ToListAsync();
        }

        public async Task<IEnumerable<JobApplication>> GetByUserIdAsync(int userId)
        {
            return await _context.Applications 
                .Include(a => a.Job)
                .Where (a => a.UserId == userId)
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
