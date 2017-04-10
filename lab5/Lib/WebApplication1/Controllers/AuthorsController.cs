using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AuthorLib;
using Lib;

namespace WebApplication1.Controllers
{
    public class AuthorsController : ApiController
    {

        AuthorRepository repo = new AuthorRepository();

        // GET: api/Authors
        public IEnumerable<string> Get()
        {
            var list = repo.GetAll();
            var allCounts = list.Select(c => c.AuthorName);
            //return new string[] { "value1", "value2" };
            return allCounts;
        }

        // GET: api/Authors/5
        public string Get(int id)
        {
            // repo.Get(id);
            return repo.Get(id).AuthorName;//"value";
        }

        public IEnumerable<string> Get([FromUri]string search)
        {
            var list = repo.GetAll();
            var all = list.Where(x => x.AuthorName.Contains(search));
            var end = all.Select(c => c.AuthorName);
            return end;
        }

        // POST: api/Authors
        public void Post([FromBody]Author author)
        {
            repo.Create(new Author { AuthorName = author.AuthorName, AuthorSurname = author.AuthorSurname, Id = author.Id});
        }

        // PUT: api/Authors/5
        public void Put(int id, [FromBody]Author value)
        {
            var a = repo.Get(id);
            a.AuthorName = value.AuthorName;
            a.AuthorSurname = value.AuthorSurname;
            repo.Update(a);
        }

        // DELETE: api/Authors/5
        public void Delete(int id)
        {
            repo.Delete(id);
        }
    }
}
