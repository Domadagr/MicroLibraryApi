using MicroLibraryAPI.Infrastructure.Data;
using MicroLibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroLibraryAPI.Features.Books.Repositories;

public class BookRepository
{
    private readonly ApplicationDbContext _context;

    public BookRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Book>> GetBooks()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task<Book?> GetBook(int id)
    {
        return await _context.Books.FindAsync(id);
    }

    public async Task<Book?> PostBook(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();

        return book;
    }

    public async Task<Book?> PutBook(int id, Book bookUpdate)
    {
        var book = await _context.Books.FindAsync(id);

        if (book == null)
        {
            return null;
        }

        book.Title = bookUpdate.Title;
        book.Author = bookUpdate.Author;
        book.Year = bookUpdate.Year;
        book.Genre = bookUpdate.Genre;
        book.Available = bookUpdate.Available;

        await _context.SaveChangesAsync();

        return book;
    }

    public async Task<bool> DeleteBook(int id)
    {
        var book = await _context.Books.FindAsync(id);

        if (book == null)
        {
            return false;
        }

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();

        return true;
        
    }
}