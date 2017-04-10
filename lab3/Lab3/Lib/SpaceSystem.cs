using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Lib
{
    [DataContract]
    public class SpaceSystem
    {
        [DataMember]
        public string Name { get; set; }
        private int MinShipPower { get; set; }
        [DataMember]
        public int BaseDistance { get; set; }
        private int Gold { get; set; }

        public SpaceSystem() { }
        public SpaceSystem(String Name, int MinShipPower, int BaseDistance, int Gold)
        {
            this.Name = Name;
            this.MinShipPower = MinShipPower;
            this.BaseDistance = BaseDistance;
            this.Gold = Gold;
        }

        public int getGold()
        {
            return this.Gold;
        }

        public int getMinShipPower()
        {
            return this.MinShipPower;
        }

    }
}
