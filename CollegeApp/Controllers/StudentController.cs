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
            return CollegeRepository.Students;
        }
        [HttpGet("{id:int}")]
        public Student GetStudentById(int id)
        {
            return CollegeRepository.Students.Where(s => s.Id == id).FirstOrDefault();
        }
    }
}
