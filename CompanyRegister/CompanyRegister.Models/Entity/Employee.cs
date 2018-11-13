using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CompanyRegister.Models.Entity
{
    public class Employee
    {
        public int Id { get; set; }
        [DisplayName("First name"), Required]
        public string FirstName { get; set; }

        [DisplayName("Second name"), Required]
        public string SecondName { get; set; }

        [DisplayName("Last name"), Required]
        public string LastName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public double Salary { get; set; }

        [DisplayName("Date of birth"), Required]
        public DateTime BirthDate { get; set; }
        [DisplayName("Hired on"), Required]
        public DateTime DateHired { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}