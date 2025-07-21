using JobBoardApi.Models;

namespace JobBoardApi.Interfaces
{
    public interface IApplicationService
    {
        Task ApplyToJobAsync(int userId, int jobId);
        public Task<IEnumerable<JobApplication>> GetApplicationsForUser(int userId);
        Task<IEnumerable<JobApplication>> GetApplicationsForJob(int jobId);
    }
}
