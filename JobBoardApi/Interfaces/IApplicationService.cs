using JobBoardApi.DTOs;
using JobBoardApi.Models;

namespace JobBoardApi.Interfaces
{
    public interface IApplicationService
    {
        Task ApplyToJobAsync(int userId, int jobId);
        public Task<IEnumerable<JobApplicationDto>> GetApplicationsForUser(int userId);
        Task<IEnumerable<JobApplicationDto>> GetApplicationsForJob(int jobId);
    }
}
