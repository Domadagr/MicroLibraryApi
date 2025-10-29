namespace MicroLibraryAPI.Features.Users.DTOs;

public class UserDto
{
    public UserDto(User user)
    {
        Id = user.Id;
        Email = user.Email;
        UserType = user.UserType;
    }
    public int Id { get; private set; }
    public string Email { get; set; } = string.Empty;
    public string UserType { get; set; } = string.Empty;
}