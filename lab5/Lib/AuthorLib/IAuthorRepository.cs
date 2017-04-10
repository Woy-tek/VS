using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib;

namespace AuthorLib
{
    public interface IAuthorRepository
    {
        List<Author> GetAll();
        int Create(Author author);
        Author Get(int Id);
        Author Update(Author author);
        bool Delete(int Id);
    }
}
