using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib;
using System.IO;
using System.Reflection;
using LiteDB;

namespace BooksLib
{
    public class BooksRepository : IBooksRepository
    {
        static string currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        static string parentPath = Path.GetFullPath(Path.Combine(currentPath, "..\\..\\.."));
        private readonly string BooksConnection = parentPath + @"\books.db";

        public List<Book> GetAll()
        {
            using (var db = new LiteDatabase(BooksConnection))
            {
                var repo = db.GetCollection<BookDB>("books");
                var res = repo.FindAll();

                return res.Select(x => Map(x)).ToList();
            }
        }

        public int Create(Book book)
        {
            using (var db = new LiteDatabase(BooksConnection))
            {
                var repo = db.GetCollection<BookDB>("books");
                var dbObj = InvMap(book);

                if (repo.FindById(book.Id) == null)
                    repo.Insert(dbObj);
                else
                    repo.Update(dbObj);

                return dbObj.Id;
            }
        }

        public Book Get(int Id)
        {
            using (var db = new LiteDatabase(BooksConnection))
            {
                var repo = db.GetCollection<BookDB>("books");
                return Map(repo.FindById(Id));
            }
        }

        public Book Update(Book book)
        {
            using (var db = new LiteDatabase(BooksConnection))
            {
                var repo = db.GetCollection<BookDB>("books");
                var dbObj = InvMap(book);
                if (repo.Update(dbObj))
                    return Map(dbObj);
                else
                    return null;
            }
        }

        public bool Delete(int Id)
        {
            using (var db = new LiteDatabase(BooksConnection))
            {
                var repo = db.GetCollection<BookDB>("books");
                return repo.Delete(Id);
            }
        }

        internal Book Map(BookDB bookDB)
        {
            if (bookDB == null)
                return null;
            return new Book() { Id = bookDB.Id, BookTitle = bookDB.BookTitle, ISBN = bookDB.ISBN };
        }

        internal BookDB InvMap(Book B)
        {
            if (B == null)
                return null;
            return new BookDB() { Id = B.Id, BookTitle = B.BookTitle, ISBN = B.ISBN };
        }
    }
}
