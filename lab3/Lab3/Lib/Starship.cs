using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Lib
{
    [DataContract]
    public class Starship
    {
        [DataMember]
        public List<Person> Crew { get; set; }
        [DataMember]
        public int Gold { get; set; }
        [DataMember]
        public int ShipPower { get; set; }

        public Starship() { }
        public Starship(int Gold, int ShipPower)
        {
            this.Crew = new List<Person>();
            this.Gold = Gold;
            this.ShipPower = ShipPower;
        }

    }
}
