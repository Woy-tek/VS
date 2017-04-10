using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib;

namespace MovieRepository
{
    public interface IMovieRep
    {
        List<Movie> GetAll();
        int Add(Movie movie);
        Movie Get(int id);
        Movie Update(Movie movie);
        bool Delete(int id);
    }
}
