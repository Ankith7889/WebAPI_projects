using System.ComponentModel.DataAnnotations;
using CollegeApp.Validators;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CollegeApp.Models
{
    public class StudentDto
    {
        [ValidateNever]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [EmailAddress(ErrorMessage ="Enter a valid email address.")]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        [DateCheck]
        public DateTime AdmissionDate { get; set; } 
    }
}
