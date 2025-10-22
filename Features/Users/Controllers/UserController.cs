using Microsoft.AspNetCore.Mvc;
using MicroLibraryAPI.Features.Users.Services;


namespace MicroLibraryAPI.Features.Users.Controllers;

[ApiController]
[Route("api/[controller]")]

public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()    
        => Ok(await _userService.GetUsers());
    

    [HttpGet("{Id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await _userService.GetUser(id);
        if (user == null)
        {
            return NotFound();
        }
        return user;
    }

    [HttpPost]
    public async Task<ActionResult<User>> PostUser(User user)
    {
        await _userService.PostUser(user);
        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(int id, User userUpdate)
    {
        var user = await _userService.PutUser(id, userUpdate);

        if (user == null)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _userService.DeleteUser(id);

        if (user == null)
        {
            return NotFound();
        }

        return NoContent();
    }
}