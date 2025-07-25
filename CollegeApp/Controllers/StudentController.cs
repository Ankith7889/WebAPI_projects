﻿using CollegeApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;

namespace CollegeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // allows us to use model binding, validation, and other features
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
        [Route("addStudent")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<StudentDto> AddStudent(StudentDto studentDto)
        {
            // Validate the incoming data if we dont use apiController attribute
            //if(ModelState.IsValid == false)
            //    return BadRequest(ModelState);
            if (studentDto == null)
                return BadRequest();
            //to manual check validtion using modelState
            //if (studentDto.AdmissionDate < DateTime.Now)
            //{
            //    ModelState.AddModelError("AdmissionDate Error", "Admission date cannot be in the past.");
            //    return BadRequest(ModelState);
            //}
            var student = new Student
            {
                Id = CollegeRepository.Students.Max(s => s.Id) + 1,
                Name = studentDto.Name, 
                Email = studentDto.Email,
                Phone = studentDto.Phone,
                AdmissionDate = studentDto.AdmissionDate
            };
            CollegeRepository.Students.Add(student);
            studentDto.Id = student.Id;
            return CreatedAtAction(nameof(GetStudentById), new { id = studentDto.Id }, studentDto);
            //get url of newly created object
        }

        [HttpPut]
        [Route("updatestudent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult UpdateStudent(StudentDto studentDto)
        {
            if (studentDto == null || studentDto.Id <= 0)
                return BadRequest();
            var student = CollegeRepository.Students.Where(s => s.Id == studentDto.Id).FirstOrDefault();
            if (student == null)
                return NotFound();
            student.Name = studentDto.Name;
            student.Email = studentDto.Email;
            student.Phone = studentDto.Phone;
            student.AdmissionDate = studentDto.AdmissionDate;
            return NoContent();
        }
        [HttpPatch]
        [Route("updatestudent/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult PatchStudent(int id, [FromBody] JsonPatchDocument<StudentDto> patchDoc)
        {
            if (patchDoc == null)
                return BadRequest();

            var student = CollegeRepository.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound();

            var studentToPatch = new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Phone = student.Phone,
                AdmissionDate = student.AdmissionDate
            };

            patchDoc.ApplyTo(studentToPatch);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            student.Name = studentToPatch.Name;
            student.Email = studentToPatch.Email;
            student.Phone = studentToPatch.Phone;
            student.AdmissionDate = studentToPatch.AdmissionDate;

            return NoContent();
        }
    }
}
