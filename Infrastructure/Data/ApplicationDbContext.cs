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
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().ToTable("books");
        modelBuilder.Entity<Book>().Property(b => b.Id).HasColumnName("id").IsRequired();
        modelBuilder.Entity<Book>().Property(b => b.Title).HasColumnName("title").IsRequired();
        modelBuilder.Entity<Book>().Property(b => b.Author).HasColumnName("author").IsRequired();
        modelBuilder.Entity<Book>().Property(b => b.Year).HasColumnName("year").IsRequired();
        modelBuilder.Entity<Book>().Property(b => b.Genre).HasColumnName("genre").IsRequired();
        modelBuilder.Entity<Book>().Property(b => b.Available).HasColumnName("available").IsRequired();

        base.OnModelCreating(modelBuilder);
    }
}