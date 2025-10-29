using System.ComponentModel.DataAnnotations;

namespace MicroLibraryAPI.Models;

public class Book
{
    //Fields are set to lowercase as I am running this on postgres
    public int Id { get; private set; }
    [Required, StringLength(100, MinimumLength = 1)]
    public string Title { get; set; } = string.Empty;
    [Required, StringLength(100, MinimumLength = 1)]
    public string Author { get; set; } = string.Empty;
    [Required, Range(0, 2100)]
    public int Year { get; set; }
    [Required, StringLength(100, MinimumLength = 1)]
    public string Genre { get; set; } = string.Empty;
    public bool Available { get; set; } = true;
}
