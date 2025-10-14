using MicroLibraryAPI.Models;
using MicroLibraryAPI.Infrastructure.Data;
using MicroLibraryAPI.Features.Books.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace MicroLibraryAPI.Features.Books;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly BookService _bookService;
    public BookController(BookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        => Ok(await _bookService.GetBooks());

    [HttpGet("{Id}")]
    public async Task<ActionResult<Book>> GetBook(int id)
    {
        var book = await _bookService.GetBook(id);

        if (book == null)
        {
            return NotFound();
        }

        return book;
    }

    [HttpPost]
    public async Task<ActionResult<Book>> PostBooks(Book book)
    {
        await _bookService.PostBook(book);

        return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> PutBook(int id, Book bookUpdate)
    {
        var book = _bookService.PutBook(id, bookUpdate);
        if (book == null)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var book = await _bookService.DeleteBook(id);

        if (!book)
        {
            return NotFound();
        }

        return NoContent();
    }

}