using AutoMapper;
using JobBoardApi.DTOs;
using JobBoardApi.Interfaces;
using JobBoardApi.Models;

namespace JobBoardApi.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _appRepo;
        private readonly IMapper _mapper;

        public ApplicationService(IApplicationRepository appRepo, IMapper mapper)
        {
            _appRepo = appRepo;
            _mapper = mapper;
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
            return _mapper.Map<IEnumerable<JobApplicationDto>>(apps);
        }

        public async Task<IEnumerable<JobApplicationDto>> GetApplicationsForJob(int jobId)
        {
            var apps = await _appRepo.GetByJobIdAsync(jobId);
            return _mapper.Map<IEnumerable<JobApplicationDto>>(apps);
        }
    }
}
