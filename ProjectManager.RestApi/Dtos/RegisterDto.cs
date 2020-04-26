using System.ComponentModel.DataAnnotations;

namespace ProjectManager.RestApi.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string UserName { get; set; }
    }
}
