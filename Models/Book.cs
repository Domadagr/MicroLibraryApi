namespace MicroLibraryAPI.Models;

public class Book
{
    //Fields are set to lowercase as I am running this on postgres
    public int Id { get; private set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public int Year { get; set; }
    public string Genre { get; set; } = string.Empty;
    public bool Available { get; set; } = true;
}
