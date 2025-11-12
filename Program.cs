// See https://aka.ms/new-console-template for more information

using Library;

var library = new Library.Library();

while (true)
{
    Console.WriteLine("\n=== Library Menu ====");
    Console.WriteLine("1 — Show all books");
    Console.WriteLine("2 — Add book");
    Console.WriteLine("3 — Remove book by id");
    Console.WriteLine("4 — Search book by title or author");
    Console.WriteLine("5 — Borrow book by id");
    Console.WriteLine("6 — Return book by id");
    Console.WriteLine("0 — Exit");
    Console.Write("Enter your choice: ");
    var input = Console.ReadLine();

    switch (input)
    {
        case "1":
            var books = library.GetAllBooks();
            
            if (books.Count == 0)
            {
                Console.WriteLine("There are no books yet!");
            }
            
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
            break;

        case "2":
            Console.Write("Title: ");
            var title = Console.ReadLine()!;
            Console.Write("Author: ");
            var author = Console.ReadLine()!;
            Console.Write("Year: ");
            int.TryParse(Console.ReadLine(), out var year);
            library.AddBook(new Book(title, author, year));
            Console.WriteLine("/n Book was added and saved");
            break;

        case "3":
            Console.Write("Enter book id for deletion: ");
            var bookRemoved = library.RemoveBook(Console.ReadLine()!);

            Console.WriteLine(bookRemoved
                ? "Book was removed and collection saved"
                : "Book was not removed and collection wasn't changed");
            break;

        case "4":
            Console.Write("Enter book title or author: ");
            var foundBook = library.GetBook(Console.ReadLine()!);

            if (foundBook == null)
            {
                Console.WriteLine("Book was not found");
            }
            
            else
            {
                Console.WriteLine("Here is the book:");
                Console.WriteLine(foundBook);
            }

            break;

        case "5":
            Console.Write("Enter book id for borrow: ");
            var borrowedBook = library.BorrowBook(Console.ReadLine()!);

            Console.WriteLine(borrowedBook ? "Book is not available!" : "Book was borrowed!");
            break;

        case "6":
            Console.Write("Enter book id for return: ");
            
            var bookReturned = library.ReturnBook(Console.ReadLine()!);
            Console.WriteLine(!bookReturned ? "Book is already available!" : $"Book was returned!");

            break;

        case "0":
            Console.WriteLine("Bye bye!");
            return;

        default:
            Console.WriteLine("Try again!");
            break;
    }
}