namespace Library;

public class Library
{
    private readonly List<Book> _books;
    private readonly BooksSavingService _booksSavingService;

    public Library()
    {
        _booksSavingService = new BooksSavingService();
        _books = _booksSavingService.GetBooks();
    }

    public bool AddBook(Book book)
    {
        int newId = _books.Any() ? _books.Max(b => b.Id) + 1 : 1;
        book = book with { Id = newId };

        _books.Add(book);
        _booksSavingService.SaveBooks(_books);

        return true;
    }

    public bool RemoveBook(string query)
    {
        var book = GetBook(query);

        if (book == null)
            return false;

        _books.Remove(book);
        _booksSavingService.SaveBooks(_books);

        return true;
    }

    public List<Book> GetAllBooks()
    {
        return _books;
    }

    public Book? GetBook(string query)
    {
        if (int.TryParse(query, out var id))
        {
            var byId = _books.FirstOrDefault(b => b.Id == id);
            if (byId != null)
                return byId;
        }
        
        return _books.FirstOrDefault(b =>
            b.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
            b.Author.Contains(query, StringComparison.OrdinalIgnoreCase));
    }

    public bool BorrowBook(string query)
    {
        var book = GetBook(query);

        if (book is { BooksStatus: BooksStatus.Borrowed })
        {
            return false;
        }

        if (book != null)
        {
            book.BooksStatus = BooksStatus.Borrowed;
        }

        _booksSavingService.SaveBooks(_books);

        return true;
    }

    public bool ReturnBook(string query)
    {
        var book = GetBook(query);

        if (book is { BooksStatus: BooksStatus.Available })
        {
            return false;
        }

        if (book != null)
        {
            book.BooksStatus = BooksStatus.Available;
        }

        _booksSavingService.SaveBooks(_books);

        return true;
    }
}