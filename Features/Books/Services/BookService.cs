using MicroLibraryAPI.Features.Books.Repositories;
using MicroLibraryAPI.Models;

namespace MicroLibraryAPI.Features.Books.Services;

public class BookService
{
    private readonly BookRepository _bookRepository;

    public BookService(BookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<IEnumerable<Book>> GetBooks()
    {
        return await _bookRepository.GetBooks();
    }

    public async Task<Book?> GetBook(int id)
    {
        return await _bookRepository.GetBook(id);
    }

    public async Task<Book?> PostBook(Book book)
    {
        return await _bookRepository.PostBook(book);
    }

    public async Task<Book?> PutBook(int id, Book bookUpdate)
    {
        return await _bookRepository.PutBook(id, bookUpdate);
    }

    public async Task<bool> DeleteBook(int id)
    {
        return await _bookRepository.DeleteBook(id);
    }
}