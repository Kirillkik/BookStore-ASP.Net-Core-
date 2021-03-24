using System;
using System.Linq;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1,"ISBN 12345-12345","D. Knuth", "Art of Programming"),
            new Book(2,"ISBN 12345-12346","M. Fowler", "Refactoring"),
            new Book(3,"ISBN 12345-12347","B. Kernigan", "C programming Language"),
        };

        public Book[] GetAllByIsbn(string isbn)
        {
            return books.Where(book => book.Isbn == isbn)
                        .ToArray();
        }

        public Book[] GetAllByTitlePartOrAuthor(string titlePartOrAuthor)
        {
            return books.Where(book => book.Title.Contains(titlePartOrAuthor)
                                    || book.Author.Contains(titlePartOrAuthor))
                        .ToArray();
        }
    }
}
