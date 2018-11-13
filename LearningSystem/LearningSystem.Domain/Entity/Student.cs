using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LearningSystem.Domain.Entity
{
    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
        }
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
