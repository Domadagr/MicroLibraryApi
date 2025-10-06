namespace MicroLibraryAPI.Models;

public class Book
{
    //Fields are set to lowercase as I am running this on postgres
    public int id { get; private set; }
    public string? title { get; set; } = string.Empty;
    public string? author { get; set; } = string.Empty;
    public int year { get; set; }
    public string? genre { get; set; } = string.Empty;
    public bool available { get; set; } = true;
}