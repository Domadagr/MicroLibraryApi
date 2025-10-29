using Microsoft.AspNetCore.Mvc;
using MicroLibraryAPI.Features.Users.Services;
using MicroLibraryAPI.Features.Users.DTOs;

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
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()    
        => Ok(await _userService.GetUsers());
    

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetUser(int id)
    {
        var user = await _userService.GetUser(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(new UserDto(user));
    }

    [HttpPost]
    public async Task<ActionResult<UserDto>> PostUser(CreateUserDto createuserdto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = new User
        {
            Email = createuserdto.Email,
            Password = createuserdto.Password,
            UserType = createuserdto.UserType,
        };

        await _userService.PostUser(user);
        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, new UserDto(user));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(int id, CreateUserDto createuserdto)
    {
        //minimal implementation, pending JWT for full implementation.
        var userUpdate = new User
        {
            Email = createuserdto.Email,
        };
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