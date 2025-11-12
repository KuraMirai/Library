namespace Library;

public record Book(string Title, string Author, int Year)
{
    public string Title { get; set; } = Title;
    public string Author { get; set; } = Author;
    public int Year { get; set; } = Year;
    public int Id { get; init; }
    public BooksStatus BooksStatus { get; set; }
}