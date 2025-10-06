using Microsoft.EntityFrameworkCore;
using MicroLibraryAPI.Models;

namespace MicroLibraryAPI.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }
    public DbSet<Book> Books { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // Configure the 'Book' entity to map to the lowercase 'books' table
    // This tells EF Core to generate: SELECT ... FROM "books" AS b
    modelBuilder.Entity<Book>().ToTable("books"); 
    
    base.OnModelCreating(modelBuilder);
}
}