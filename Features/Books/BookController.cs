using MicroLibraryAPI.Models;
using MicroLibraryAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace MicroLibraryAPI.Features.Books;

[ApiController]
[Route("api/controller")]
public class BookController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public BookController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet(Name = "GetBooks")]
    public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
    {
        return await _context.Books.ToListAsync();
    }

}