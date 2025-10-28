using MicroLibraryAPI.Models;

namespace MicroLibraryAPI.Features.Books.DTOs;

public class BookDto
{
    public BookDto(Book book)
    {
        Id = book.Id;
        Title = book.Title;
        Author = book.Author;
        Year = book.Year;
        Genre = book.Genre;
        Available = book.Available;
    }
    
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public int Year { get; set; }
    public string Genre { get; set; } = string.Empty;
    public bool Available { get; set; } = true;
}