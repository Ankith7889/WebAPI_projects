using JobBoardApi.Interfaces;
using JobBoardApi.Models;

namespace JobBoardApi.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _appRepo;

        public ApplicationService(IApplicationRepository appRepo)
        {
            _appRepo = appRepo;
        }

        public async Task ApplyToJobAsync(int userId, int jobId)
        {
            var application = new JobApplication
            {
                UserId = userId,
                JobId = jobId
            };

            await _appRepo.AddAsync(application);
            await _appRepo.SaveChangesAsync();
        }

        public async Task<IEnumerable<JobApplication>> GetApplicationsForUser(int userId)
        {
            return await _appRepo.GetByUserIdAsync(userId);
        }

        public async Task<IEnumerable<JobApplication>> GetApplicationsForJob(int jobId)
        {
            return await _appRepo.GetByJobIdAsync(jobId);
        }
    }
}
