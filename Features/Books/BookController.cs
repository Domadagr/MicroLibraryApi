using MicroLibraryAPI.Models;
using MicroLibraryAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace MicroLibraryAPI.Features.Books;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public BookController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
    {
        return await _context.Books.ToListAsync();
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<Book>> GetBook(int id)
    {
        var book = await _context.Books.FindAsync(id);

        if (book == null)
        {
            return NotFound();
        }

        return book;
    }

    [HttpPost]
    public async Task<ActionResult<Book>> PostBooks(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> PutBook(int id, Book bookUpdate)
    {
        var book = await _context.Books.FindAsync(id);

        if (book == null)
        {
            return NotFound();
        }

        book.Title = bookUpdate.Title;
        book.Author = bookUpdate.Author;
        book.Year = bookUpdate.Year;
        book.Genre = bookUpdate.Genre;
        book.Available = bookUpdate.Available;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var book = await _context.Books.FindAsync(id);

        if (book == null)
        {
            return NotFound();
        }

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();

        return NoContent();
    }

}