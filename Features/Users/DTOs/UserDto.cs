namespace MicroLibraryAPI.Features.Users.DTOs;

public class UserDto
{
    public int Id { get; private set; }
    public string? Email { get; set; } = string.Empty;
    public string? UserType { get; set; } = string.Empty;    
}