using JobBoardApi.DTOs;
using JobBoardApi.Interfaces;
using JobBoardApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobService _jobService;
        public JobsController(IJobService jobService) 
        {
            _jobService = jobService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var jobs = await _jobService.GetAllJobsAsync();
            return Ok(jobs);
        }
        [HttpPost]
        [Authorize(Roles = "Employer,Admin")]
        public async Task<IActionResult> Create([FromBody] CreateJobDto dto)
        {
            var job = new Job
            {
                Title = dto.Title,
                Description = dto.Description,
                Company = dto.Company
            };

            var created = await _jobService.CreateJobAsync(job);
            return CreatedAtAction(nameof(GetAll), new { id = created.Id }, created);
        }
        [HttpPut("{id}/approve")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ApproveJob(int id)
        {
            var job = await _jobService.GetJobByIdAsync(id);
            if (job == null) return NotFound();

            job.IsApproved = true;
            await _jobService.UpdateJobAsync(job);

            return Ok(new { message = "Job approved" });
        }

    }
}
