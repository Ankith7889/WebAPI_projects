using CollegeApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollegeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Student> GetStudentDetails()
        {
            return new List<Student> { new Student
            {
                Id = 1,
                Name = "Ankith",
                Email = "Ankith@gmail.com",
                Phone = "8976573601"
            }
            };
        }
    }
}
