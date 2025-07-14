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
        public ActionResult<Student> GetStudentById(int id)
        {   
            if (id <= 0)
                return BadRequest();
            var student= CollegeRepository.Students.Where(s => s.Id == id).FirstOrDefault();
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        [HttpGet("{name:alpha}")]
        public ActionResult<Student> GetStudentByname(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest();
            var student = CollegeRepository.Students.Where(s => s.Name == name).FirstOrDefault();
            if (student == null)
                return NotFound();
            return Ok(student);
        }
        [HttpDelete("{id:int}")]
        public bool DeleteStudentById(int id)
        {
            var student = CollegeRepository.Students.Where(s => s.Id == id).FirstOrDefault();
            CollegeRepository.Students.Remove(student);
            return true;
        }
    }
}
