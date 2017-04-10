using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using Lib;
using LiteDB;

namespace AuthorLib
{
    public class AuthorRepository : IAuthorRepository
    {
        static string currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        static string parentPath = Path.GetFullPath(Path.Combine(currentPath, "..\\..\\.."));
        private readonly string AuthorsConnection = parentPath + @"\authors.db";

        public List<Author> GetAll()
        {
            using( var db = new LiteDatabase(AuthorsConnection))
            {
                var repo = db.GetCollection<AuthorDB>("authors");
                var res = repo.FindAll();

                return res.Select(x => Map(x)).ToList();
            }
        }

        public int Create(Author author)
        {
            using(var db = new LiteDatabase(AuthorsConnection))
            {
                var repo = db.GetCollection<AuthorDB>("authors");
                var dbObj = InvMap(author);
                if (repo.FindById(author.Id) == null)
                {
                    repo.Insert(dbObj);
                }
                else
                {
                    repo.Update(dbObj);
                }
                return dbObj.Id;
            }
        }

        public Author Get(int Id)
        {
            using (var db = new LiteDatabase(AuthorsConnection))
            {
                var repo = db.GetCollection<AuthorDB>("authors");
                var dbObj = repo.FindById(Id);
                if(dbObj == null)
                {
                    return null;
                }
                else
                {
                    return Map(dbObj);
                }
            }
        }

        public Author Update(Author author)
        {
            using ( var db = new LiteDatabase(AuthorsConnection))
            {
                var repo = db.GetCollection<AuthorDB>("authors");
                var dbObj = InvMap(author);
                if (repo.Update(dbObj))
                {
                    return Map(dbObj);
                }
                else
                {
                    return null;
                }
            }
        }

        public bool Delete(int Id)
        {
            using( var db = new LiteDatabase(AuthorsConnection))
            {
                var repo = db.GetCollection<AuthorDB>("authors");
                return repo.Delete(Id);
            }
        }

        internal Author Map(AuthorDB authorDB)
        {
            if(authorDB == null)
            {
                return null;
            }
            else
            {
                return new Author() { Id = authorDB.Id, AuthorName = authorDB.AuthorName, AuthorSurname = authorDB.AuthorSurname };
            }
        }

        internal AuthorDB InvMap(Author author)
        {
            if (author == null)
            {
                return null;
            }
            else
            {
                return new AuthorDB() { Id = author.Id, AuthorName = author.AuthorName, AuthorSurname = author.AuthorSurname };
            }
        }

    }
}
