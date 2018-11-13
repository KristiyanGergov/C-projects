using LearningSystem.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningSystem.Domain.View
{
    public class RegisterStudentViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }

        public IEnumerable<Course> Courses { get; set; }
    }
}
