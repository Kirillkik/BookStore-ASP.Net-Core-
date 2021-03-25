using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    public interface IBookRepository
    {
        Book[] GetAllByIsbn(string isbn);

        Book[] GetAllByTitlePartOrAuthor(string titlePartOrAuthor);
        Book GetById(int id);
    }
}
