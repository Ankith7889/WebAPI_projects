using JobBoardApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationsController : ControllerBase
    {
        private readonly IApplicationService _appService;

        public ApplicationsController(IApplicationService appService)
        {
            _appService = appService;
        }

        [HttpPost("{userId}/apply/{jobId}")]
        public async Task<IActionResult> Apply(int userId, int jobId)
        {
            await _appService.ApplyToJobAsync(userId, jobId);
            return Ok(new { message = "Applied successfully" });
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUser(int userId)
        {
            var apps = await _appService.GetApplicationsForUser(userId);
            return Ok(apps);
        }

        [HttpGet("job/{jobId}")]
        public async Task<IActionResult> GetByJob(int jobId)
        {
            var apps = await _appService.GetApplicationsForJob(jobId);
            return Ok(apps);
        }
    }

}
