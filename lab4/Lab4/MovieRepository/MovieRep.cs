using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib;
using LiteDB;
using System.IO;

namespace MovieRepository
{
    public class MovieRep : IMovieRep
    {
        private readonly string Connection = @"D:\bazy\movies.db";

        internal Movie Map(MovieDB movie)
        {
            if(movie == null)
            {
                return null;
            }
            else
            {
                return new Movie() { Id = movie.Id, ReleaseYear = movie.ReleaseYear, Title = movie.Title};
            }
        }

        internal MovieDB InvMap(Movie movie)
        {
            if (movie == null)
            {
                return null;
            }
            else
            {
                return new MovieDB() { Id = movie.Id, ReleaseYear = movie.ReleaseYear, Title = movie.Title };
            }
        }

        public List<Movie> GetAll()
        {
            using (var db = new LiteDatabase(this.Connection))
            {
                var repo = db.GetCollection<MovieDB>("movies");
                var result = repo.FindAll();
                if(repo == null)
                {
                    return null;
                }
                else
                {
                    return result.Select(x => Map(x)).ToList();
                }
            }
        }

        public int Add(Movie movie)
        {
            using (var db = new LiteDatabase(this.Connection))
            {
                var repo = db.GetCollection<MovieDB>("movies");
                if(repo.FindById(movie.Id) != null)
                {
                    repo.Update(InvMap(movie));
                }
                else
                {
                    repo.Insert(InvMap(movie));
                }
                return movie.Id;
            }
        }
        public Movie Get(int id)
        {
            using (var db = new LiteDatabase(this.Connection))
            {
                var repo = db.GetCollection<MovieDB>("movies");
                var obj = repo.FindById(id);
                if(obj != null)
                {
                    return Map(obj);
                }
                else
                {
                    return null;
                }
            }
        }
        public Movie Update(Movie movie)
        {
            using ( var db = new LiteDatabase(this.Connection))
            {
                var repo = db.GetCollection<MovieDB>("movies");
                var obj = InvMap(movie);
                if(repo.Update(obj))
                {
                    return movie;
                }
                else
                {
                    return null;
                }
            }
        }
        public bool Delete(int id)
        {
            using ( var db = new LiteDatabase(this.Connection))
            {
                var repo = db.GetCollection<MovieDB>("movies");
                return repo.Delete(id);
            }
        }
    }
}
