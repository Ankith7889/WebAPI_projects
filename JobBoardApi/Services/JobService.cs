using JobBoardApi.Interfaces;
using JobBoardApi.Models;

namespace JobBoardApi.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        public JobService(IJobRepository jobRepository)
        { 
            _jobRepository = jobRepository;
        }

        public async Task<Job> CreateJobAsync(Job job)
        {
            await _jobRepository.AddAsync(job);
            await _jobRepository.SaveChangesAsync();
            return job;
        }
        public async Task DeleteJobAsync(int id)
        {
            var job = await _jobRepository.GetByIdAsync(id);
            if (job != null)
            {
                await _jobRepository.DeleteAsync(job);
                await _jobRepository.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Job>> GetAllJobsAsync()
        {
            return await _jobRepository.GetAllAsync();
        }
        public async Task<Job?> GetJobByIdAsync(int id)
        {
            return await _jobRepository.GetByIdAsync(id);
        }
        public async Task UpdateJobAsync(Job job)
        {
            await _jobRepository.SaveChangesAsync();  // job is already tracked
        }

    }
}
