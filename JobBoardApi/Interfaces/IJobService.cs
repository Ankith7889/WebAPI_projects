using JobBoardApi.Models;

namespace JobBoardApi.Interfaces
{
    public interface IJobService
    {
        Task<IEnumerable<Job>> GetAllJobsAsync();
        Task<Job?> GetJobByIdAsync(int id);
        Task<Job> CreateJobAsync(Job job);
        Task DeleteJobAsync(int id);
    }   
}
