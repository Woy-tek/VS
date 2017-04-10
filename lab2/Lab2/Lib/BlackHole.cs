using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Lib
{
    public class BlackHole : IBlackHole
    {
        public Starship PullStarship(Starship ship)
        {
            if(ship.Captain.Age > 40)
            {
                foreach(Person p in ship.Crew)
                {
                    p.Age += 20;
                }
            }
            return ship;
        }

        public string UltimateAnswer() {
            return 42.ToString();
        }
    }
}
