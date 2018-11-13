using System.ComponentModel.DataAnnotations;

namespace BazarCamera.Domain.View
{
    public class LoginVm
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}