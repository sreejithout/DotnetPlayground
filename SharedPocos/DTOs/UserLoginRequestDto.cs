using System.ComponentModel.DataAnnotations;

namespace SharedPocos.DTOs;

public class UserLoginRequestDto
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}
