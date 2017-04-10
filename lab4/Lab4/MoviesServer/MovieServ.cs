using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Lib;
using MovieRepository;

namespace MoviesServer
{
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę klasy „Service1” w kodzie i pliku konfiguracji.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MovieServ : IMovieServ
    {

        private readonly MovieRep rep = new MovieRep();

        public List<Movie> GetAll()
        {
            return rep.GetAll();
        }

        public int Add(Movie movie)
        {
            return rep.Add(movie);
        }

        public Movie Get(int id)
        {
            return rep.Get(id);
        }

        public Movie Update(Movie movie)
        {
            return rep.Update(movie);
        }

        public bool Delete(int id)
        {
            return rep.Delete(id);
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
