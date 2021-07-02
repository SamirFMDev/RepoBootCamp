using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    class Toyota: LandTransport
    {
        public Toyota()
        {
            SpeedLimit = 120;
            PeopleCapacity = 6;
            Wheels = 4;
        }
        public override string ToString()
        {
            return $"The Toyota {base.ToString()}";
        }
    }

    class ElectricFlyingCar: AirLandTransport
    {
        public ElectricFlyingCar()
        {
            SpeedLimit = 120;
            PeopleCapacity = 4;
            MaxHeight = 18288;
            Wheels = 4;
        }
        public override string ToString()
        {
            return $"The Electric Flying Car {base.ToString()}";
        }
    }

    class Boat: AquaticTransport
    {
        public Boat()
        {
            SpeedLimit = 60;
            PeopleCapacity = 20;
        }
        public override string ToString()
        {
            return $"The {base.ToString()}";
        }
    }

    class Boeing: AirTransport
    {
        public Boeing()
        {
            SpeedLimit = 200;
            PeopleCapacity = 30;
            MaxHeight = 18288;
        }
        public override string ToString()
        {
            return $"The Boeing {base.ToString()}";
        }
    }
}
