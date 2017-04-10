using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{

    public class Starship
    {
        public string Name { get; set; }
        public Person Captain { get; set; }
        public List<Person> Crew { get; set; }

        public Starship() { }
        public void PresentCrew()
        {
            Console.WriteLine("DANE STATKU:");
            Console.WriteLine("NAZWA: " + this.Name);
            Console.WriteLine("KAPITAN: " + this.Captain.Name);
            Console.WriteLine("ZAŁOGA: ");
            foreach(Person p in this.Crew)
            {
                Console.WriteLine(p.Name);
            }
        }
    }
}
