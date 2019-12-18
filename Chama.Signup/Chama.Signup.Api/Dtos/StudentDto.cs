using System.ComponentModel.DataAnnotations;

namespace Chama.Signup.Api.Dtos
{
    public class StudentDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public int Age { get; set; }
    }
}
