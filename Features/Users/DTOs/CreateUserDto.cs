using System.ComponentModel.DataAnnotations;

namespace MicroLibraryAPI.Features.Users.DTOs;

public class CreateUserDto
{
    [Required, StringLength(100, MinimumLength = 1)]
    public string Email { get; set; } = string.Empty;

    [Required, StringLength(100, MinimumLength = 1)]
    public string Password { get; set; } = string.Empty;

    [Required, StringLength(100, MinimumLength = 1)]
    public string UserType { get; set; } = string.Empty;

}