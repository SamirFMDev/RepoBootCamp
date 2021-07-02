using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    class Brands{}
    class Toyota: LandTransport
    {
        public override string ToString()
        {
            return $"The Toyota {base.ToString()}";
        }
    }

    class ElectricFlyingCar: AirTransport
    {
        public override string ToString()
        {
            return $"The Electric Flying Car {base.ToString()}";
        }
    }

    class Boat: AquaticTransport
    {
        public override string ToString()
        {
            return $"The {base.ToString()}";
        }
    }

    class Boeing: AirTransport
    {
        public override string ToString()
        {
            return $"The Boeing {base.ToString()}";
        }
    }
}
