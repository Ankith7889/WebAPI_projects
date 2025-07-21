using JobBoardApi.Models;

namespace JobBoardApi.Interfaces
{
    public interface IApplicationRepository
    {
        Task<IEnumerable<JobApplication>> GetByUserIdAsync(int userId);
        Task<IEnumerable<JobApplication>> GetByJobIdAsync(int jobId);
        Task AddAsync(JobApplication application);
        Task SaveChangesAsync();
    }

}
