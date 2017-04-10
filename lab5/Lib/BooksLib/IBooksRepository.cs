using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib;

namespace BooksLib
{
    public interface IBooksRepository
    {
        List<Book> GetAll();
        int Create(Book book);
        Book Get(int Id);
        Book Update(Book book);
        bool Delete(int Id);
    }
}
