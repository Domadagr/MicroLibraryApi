using MicroLibraryAPI.Models;
using MicroLibraryAPI.Features.Books.Services;
using Microsoft.AspNetCore.Mvc;
using MicroLibraryAPI.Features.Books.DTOs;

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
    public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
        => Ok(await _bookService.GetBooks());


    [HttpGet("{id}")]
    public async Task<ActionResult<BookDto>> GetBook(int id)
    {
        var book = await _bookService.GetBook(id);

        if (book == null)
        {
            return NoContent();
        }
        return Ok(new BookDto(book));
    }

    [HttpPost]
    public async Task<ActionResult<BookDto>> PostBook(CreateBookDto createbookdto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var book = new Book
        {
            Title = createbookdto.Title,
            Author = createbookdto.Author,
            Year = createbookdto.Year,
            Genre = createbookdto.Genre,
            Available = true,
        };

        await _bookService.PostBook(book);
        return CreatedAtAction(nameof(GetBook), new { id = book.Id }, new BookDto(book));

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutBook(int id, CreateBookDto createbookdto)
    {
        var bookUpdate = new Book
        {
            Title = createbookdto.Title,
            Author = createbookdto.Author,
            Year = createbookdto.Year,
            Genre = createbookdto.Genre,
            Available = createbookdto.Available,
        };

        var book = await _bookService.PutBook(id, bookUpdate);
        if (book == null)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var book = await _bookService.DeleteBook(id);

        if (book == null)
        {
            return NotFound();
        }

        return NoContent();
    }

}