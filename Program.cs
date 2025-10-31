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
            library.ShowBooks();
            break;

        case "2":
            Console.Write("Title: ");
            var title = Console.ReadLine()!;
            Console.Write("Author: ");
            var author = Console.ReadLine()!;
            Console.Write("Year: ");
            int.TryParse(Console.ReadLine(), out var year);
            Console.Write("Id: ");
            int.TryParse(Console.ReadLine(), out var id);
            library.AddBook(new Book(title, author, year, id));
            break;

        case "3":
            Console.Write("Enter book id for deletion: ");
            int.TryParse(Console.ReadLine(), out var deleteId);
            library.RemoveBook(deleteId);
            break;

        case "4":
            Console.Write("Enter book title or author: ");
            library.SearchBook(Console.ReadLine()!);
            break;

        case "5":
            Console.Write("Enter book id for borrow: ");
            int.TryParse(Console.ReadLine(), out var borrowId);
            library.BorrowBook(borrowId);
            break;

        case "6":
            Console.Write("Enter book id for return: ");
            int.TryParse(Console.ReadLine(), out var returnId);
            library.ReturnBook(returnId);
            break;

        case "0":
            Console.WriteLine("Bye bye!");
            return;

        default:
            Console.WriteLine("Try again!");
            break;
    }
}