using System.ComponentModel.DataAnnotations;

namespace mbanq.API.Dtos
{
    public class LoginDto
    {
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        [StringLength(256, MinimumLength = 8, ErrorMessage = "Password must have at least 8 characters")]
        public string Password { get; set; } = null!;
    }
}
