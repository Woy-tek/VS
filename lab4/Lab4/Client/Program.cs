using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesServer;
using Lib;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Client.MovServ.MovieServClient MovieClient = new MovServ.MovieServClient();
        //    MovieClient.Add(new Movie() { Id = 1, Title = "Lord of the Rings", ReleaseYear = 1999});
            Movie[] lista = MovieClient.GetAll();
            foreach(Movie m in lista)
            {
                Console.WriteLine(m.Id+" "+m.ReleaseYear+" "+m.Title);
            }
            Console.ReadKey();
        }
    }
}
