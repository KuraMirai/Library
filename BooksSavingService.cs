using System.Text.Json;

namespace Library;

public class BooksSavingService
{
    private readonly string _filePath = "data/books.txt";

    public BooksSavingService()
    {
        Directory.CreateDirectory(Path.GetDirectoryName(_filePath)!);
    }

    public List<Book> GetBooks()
    {
        if (!File.Exists(_filePath))
            return new List<Book>();

        var json = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
    }
    
    public void SaveBooks(List<Book> books)
    {
        var json = JsonSerializer.Serialize(books, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json);
    }
}