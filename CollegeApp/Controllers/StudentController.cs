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
        public IEnumerable<StudentDto> GetStudentDetails()
        {
            var students = CollegeRepository.Students.Select(s => new StudentDto
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                Phone = s.Phone
            });
            return students;
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]//documentaion of response types
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<StudentDto> GetStudentById(int id)
        {
            if (id <= 0)
                return BadRequest();
            var student = CollegeRepository.Students.Where(s => s.Id == id).FirstOrDefault();
            if (student == null)
                return NotFound();
            var studentDto = new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Phone = student.Phone
            };
            return Ok(studentDto);
        }

        [HttpGet("{name:alpha}")]
        public ActionResult<StudentDto> GetStudentByname(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest();
            var student = CollegeRepository.Students.Where(s => s.Name == name).FirstOrDefault();
            if (student == null)
                return NotFound();
            var studentDto = new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Phone = student.Phone
            };
            return Ok(studentDto);
        }
        [HttpDelete("{id:int}")]
        public bool DeleteStudentById(int id)
        {
            var student = CollegeRepository.Students.Where(s => s.Id == id).FirstOrDefault();
            CollegeRepository.Students.Remove(student);
            return true;
        }
        [HttpPost]
        [Route("addstudent")]
        public ActionResult<StudentDto> AddStudent([FromBody]StudentDto studentDto)
        {
            if (studentDto == null)
                return BadRequest();
            var student = new Student
            {
                Id = CollegeRepository.Students.Max(s => s.Id) + 1,
                Name = studentDto.Name,
                Email = studentDto.Email,
                Phone = studentDto.Phone
            };
            CollegeRepository.Students.Add(student);
            studentDto.Id = student.Id; 
            return Ok(studentDto);
        }
    }
}
