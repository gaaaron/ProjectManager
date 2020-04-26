using System.ComponentModel.DataAnnotations;

namespace ProjectManager.RestApi.Dtos
{
    public class AuthenticateDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
