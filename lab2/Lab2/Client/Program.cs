using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib;
using Client.BlackHoleServer;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Starship s = new Starship() { Name = "Sokół", Captain = new Person()
            { Name = "Han Solo", Age = 20 }, Crew = new List<Person>() };
            s.Crew.Add(new Person() { Name = "Chewbacca", Age = 50 });

            BlackHoleClient srv = new BlackHoleClient();
            srv.PullStarship(s).PresentCrew();
            Console.ReadKey();
        }
    }
}
