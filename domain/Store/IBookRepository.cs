using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    public interface IBookRepository
    {
        Book[] GetAllByTitlePart(string titlePart);
    }
}
