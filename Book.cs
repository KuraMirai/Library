namespace Library;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public int Id { get; set; }
    public bool IsAvailable { get; set; } = true;

    public Book(string title, string author, int year, int id)
    {
        Title = title;
        Author = author;
        Year = year;
        Id = id;
    }

    public override string ToString()
    {
        var isAvailable = IsAvailable ? "Available" : "Not available";
        return $"{Title} - {Author} - {Year} - {Id} - {isAvailable}";
    }
}