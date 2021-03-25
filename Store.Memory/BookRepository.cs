using System;
using System.Linq;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1,"ISBN 12345-12345","D. Knuth", "Art of Programming", "Good book", 10m),
            new Book(2,"ISBN 12345-12346","M. Fowler", "Refactoring", "Good book", 30m),
            new Book(3,"ISBN 12345-12347","B. Kernigan", "C programming Language", "Good book", 20m)
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

        public Book GetById(int id)
        {
            return books.Single(book => book.Id == id);
        }
    }
}
