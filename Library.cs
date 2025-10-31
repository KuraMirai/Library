namespace Library;

public class Library
{
    private List<Book> _books;
    private BooksSavingService _booksSavingService;

    public Library()
    {
        _booksSavingService = new BooksSavingService();
        _books = _booksSavingService.GetBooks();
    }

    public void AddBook(Book book)
    {
        if (_books.Any(b => b.Id == book.Id))
        {
            Console.WriteLine($"Book with id = {book.Id} already exists and won't be added!");
            return;
        }

        _books.Add(book);
        _booksSavingService.SaveBooks(_books);
        Console.WriteLine("Book was added and saved");
    }

    public void RemoveBook(int id)
    {
        var book = _books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            Console.WriteLine($"Book with id = {id} does not exist!");
            return;
        }

        _books.Remove(book);
        _booksSavingService.SaveBooks(_books);
        Console.WriteLine("Book was removed and collection saved");
    }

    public void ShowBooks()
    {
        if (_books.Count == 0)
        {
            Console.WriteLine("There are no books yet!");
        }

        foreach (var book in _books)
        {
            Console.WriteLine(book);
        }
    }

    public void SearchBook(string searchString)
    {
        var books = _books.Where(b =>
            b.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
            b.Author.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();

        if (books.Count == 0)
        {
            Console.WriteLine("There are no books found!");
            return;
        }

        Console.WriteLine($"Found {books.Count} books!");
        Console.WriteLine($"Here are the books:");
        
        foreach (var book in books)
        {
            Console.WriteLine(book);
        }
    }
    
    public void BorrowBook(int id)
    {
        var book = _books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            Console.WriteLine($"Book with id = {id} does not exist!");
            return;
        }

        if (!book.IsAvailable)
        {
            Console.WriteLine("Book is not available!");
            return;
        }
        
        book.IsAvailable = false;
        _booksSavingService.SaveBooks(_books);
        Console.WriteLine($"Book was with id = {id} was borrowed!");
    }
    
    public void ReturnBook(int id)
    {
        var book = _books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            Console.WriteLine($"Book with id = {id} does not exist!");
            return;
        }

        if (book.IsAvailable)
        {
            Console.WriteLine("Book is already available!");
            return;
        }
        
        book.IsAvailable = true;
        _booksSavingService.SaveBooks(_books);
        Console.WriteLine($"Book was with id = {id} was returned!");
    }
    
}