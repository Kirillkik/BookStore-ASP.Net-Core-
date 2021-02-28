using System;
using System.Linq;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1, "Art of Programming"),
            new Book(2, "Refactoring"),
            new Book(1, "C programming Language"),
        };

        public Book[] GetAllByTitlePart(string titlePart)
        {
            return books.Where(book => book.Title.Contains(titlePart)).ToArray();
        }
    }
}
