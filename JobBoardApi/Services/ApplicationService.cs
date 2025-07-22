using JobBoardApi.DTOs;
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

        public async Task<IEnumerable<JobApplicationDto>> GetApplicationsForUser(int userId)
        {
            var apps = await _appRepo.GetByUserIdAsync(userId);

            return apps.Select(app => new JobApplicationDto
            {
                Id = app.Id,
                JobId = app.JobId,
                JobTitle = app.Job.Title,
                UserId = app.UserId,
                Username = app.User.Username,
                AppliedAt = app.AppliedAt
            });
        }

        public async Task<IEnumerable<JobApplicationDto>> GetApplicationsForJob(int jobId)
        {
            var apps = await _appRepo.GetByJobIdAsync(jobId);

            return apps.Select(app => new JobApplicationDto
            {
                Id = app.Id,
                JobId = app.JobId,
                JobTitle = app.Job.Title,
                UserId = app.UserId,
                Username = app.User.Username,
                AppliedAt = app.AppliedAt
            });
        }
    }
}
