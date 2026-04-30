class LibraryManager
{
    static void Main()
    {
        const int capacity = 5;
        const int maxBorrowed = 3;
        string?[] available = new string?[capacity];
        string?[] borrowed = new string?[maxBorrowed];

        bool HasSpaceAvailable() => available.Any(b => b is null);
        bool HasSpaceBorrowed() => borrowed.Any(b => b is null);
        bool HasBooksAvailable() => available.Any(b => b is not null);

        bool AddBook(string title)
        {
            for (int i = 0; i < available.Length; i++)
            {
                if (available[i] is null)
                {
                    available[i] = title;
                    return true;
                }
            }
            return false;
        }

        bool RemoveBook(string title)
        {
            for (int i = 0; i < available.Length; i++)
            {
                if (string.Equals(available[i], title, StringComparison.OrdinalIgnoreCase))
                {
                    available[i] = null;
                    return true;
                }
            }
            return false;
        }

        bool BorrowBook(string title)
        {
            if (!HasSpaceBorrowed()) return false;

            for (int i = 0; i < available.Length; i++)
            {
                if (string.Equals(available[i], title, StringComparison.OrdinalIgnoreCase))
                {
                    available[i] = null;
                    for (int j = 0; j < borrowed.Length; j++)
                    {
                        if (borrowed[j] is null)
                        {
                            borrowed[j] = title;
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        bool ReturnBook(string title)
        {
            for (int i = 0; i < borrowed.Length; i++)
            {
                if (string.Equals(borrowed[i], title, StringComparison.OrdinalIgnoreCase))
                {
                    borrowed[i] = null;
                    AddBook(title); // should always have space after return
                    return true;
                }
            }
            return false;
        }

        bool IsBorrowed(string title) => borrowed.Any(b => string.Equals(b, title, StringComparison.OrdinalIgnoreCase));

        void SearchBook(string title)
        {
            if (available.Any(b => string.Equals(b, title, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine($"'{title}' is available in the library.");
            }
            else if (IsBorrowed(title))
            {
                Console.WriteLine($"'{title}' is currently borrowed.");
            }
            else
            {
                Console.WriteLine($"'{title}' is not in the collection.");
            }
        }

        void ShowBooks()
        {
            if (!HasBooksAvailable() && !borrowed.Any(b => b is not null))
            {
                Console.WriteLine("The library is empty.");
                return;
            }

            Console.WriteLine("Available books:");
            foreach (var book in available)
            {
                if (!string.IsNullOrWhiteSpace(book)) Console.WriteLine($"- {book}");
            }

            Console.WriteLine("Borrowed books:");
            foreach (var book in borrowed)
            {
                if (!string.IsNullOrWhiteSpace(book)) Console.WriteLine($"- {book}");
            }
        }

        Console.WriteLine("Library Manager (extended).");

        while (true)
        {
            Console.Write("Choose an action (add/remove/borrow/return/search/show/exit): ");
            var action = Console.ReadLine()?.Trim().ToLowerInvariant();

            switch (action)
            {
                case "add":
                    if (!HasSpaceAvailable())
                    {
                        Console.WriteLine("The library is full. No more books can be added.");
                        break;
                    }

                    Console.Write("Enter the title of the book to add: ");
                    var newBook = Console.ReadLine()?.Trim();
                    if (string.IsNullOrWhiteSpace(newBook))
                    {
                        Console.WriteLine("The title cannot be empty.");
                        break;
                    }

                    AddBook(newBook);
                    Console.WriteLine($"Book added: {newBook}");
                    break;

                case "remove":
                    if (!HasBooksAvailable())
                    {
                        Console.WriteLine("The library is empty. No books to remove.");
                        break;
                    }

                    Console.Write("Enter the title of the book to remove: ");
                    var removeBook = Console.ReadLine()?.Trim();
                    if (string.IsNullOrWhiteSpace(removeBook))
                    {
                        Console.WriteLine("The title cannot be empty.");
                        break;
                    }

                    if (RemoveBook(removeBook))
                    {
                        Console.WriteLine($"Book removed: {removeBook}");
                    }
                    else
                    {
                        Console.WriteLine("Book not found.");
                    }
                    break;

                case "borrow":
                    if (!HasBooksAvailable())
                    {
                        Console.WriteLine("No available books to borrow.");
                        break;
                    }
                    if (!HasSpaceBorrowed())
                    {
                        Console.WriteLine($"Borrow limit reached ({maxBorrowed}). Return a book before borrowing another.");
                        break;
                    }

                    Console.Write("Enter the title of the book to borrow: ");
                    var borrowTitle = Console.ReadLine()?.Trim();
                    if (string.IsNullOrWhiteSpace(borrowTitle))
                    {
                        Console.WriteLine("The title cannot be empty.");
                        break;
                    }

                    if (BorrowBook(borrowTitle))
                    {
                        Console.WriteLine($"Borrowed: {borrowTitle}");
                    }
                    else
                    {
                        Console.WriteLine("Book not found in available list.");
                    }
                    break;

                case "return":
                    if (!borrowed.Any(b => b is not null))
                    {
                        Console.WriteLine("You have no borrowed books to return.");
                        break;
                    }

                    Console.Write("Enter the title of the book to return: ");
                    var returnTitle = Console.ReadLine()?.Trim();
                    if (string.IsNullOrWhiteSpace(returnTitle))
                    {
                        Console.WriteLine("The title cannot be empty.");
                        break;
                    }

                    if (ReturnBook(returnTitle))
                    {
                        Console.WriteLine($"Returned: {returnTitle}");
                    }
                    else
                    {
                        Console.WriteLine("That book is not marked as borrowed.");
                    }
                    break;

                case "search":
                    Console.Write("Enter the title to search: ");
                    var searchTitle = Console.ReadLine()?.Trim();
                    if (string.IsNullOrWhiteSpace(searchTitle))
                    {
                        Console.WriteLine("The title cannot be empty.");
                        break;
                    }
                    SearchBook(searchTitle);
                    break;

                case "show":
                    ShowBooks();
                    break;

                case "exit":
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid action. Please type 'add', 'remove', 'show', or 'exit'.");
                    break;
            }

            ShowBooks();
        }
    }
}
