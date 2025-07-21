using JobBoardApi.DTOs;
using JobBoardApi.Interfaces;
using JobBoardApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardApi.Controllers
{
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
            var jobs = _jobService.GetAllJobsAsync();
            return Ok(jobs);
        }
        [HttpPost]
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
    }
}
