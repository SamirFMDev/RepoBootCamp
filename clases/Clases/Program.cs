using System;

namespace Clases
{
    class Program
    {
        static void Main(string[] args)
        {
            Toyota toyota = new Toyota();
            toyota.SpeedLimit = 50;
            toyota.Land();
            Console.WriteLine(toyota.ToString());

            ElectricFlyingCar electricFlyingCar = new ElectricFlyingCar();
            electricFlyingCar.Fly();
            electricFlyingCar.Land();
            Console.WriteLine(electricFlyingCar.ToString());

            Boat boat = new Boat();
            boat.Navigate();
            Console.WriteLine(boat.ToString());

            Boeing boeing = new Boeing();
            boeing.Land();
            Console.WriteLine(boeing.ToString());
        }
    }

    abstract class Transport
    {
        public int SpeedLimit { get; set; }
        public int PeopleCapacity { get; set; }

        public override string ToString()
        {
            return $"can reach {SpeedLimit} km/h, with a capacity of {PeopleCapacity} persons";
        }
    }
    class AirTransport: Transport
    {
        public int MaxHeight { get; set; }

        public void Fly()
        {
            Console.WriteLine("Flying...");
        }
        public void Land()
        {
            Console.WriteLine("Landing...");
        }
        public override string ToString()
        {
            return $"plane {base.ToString()} and a maximum altitud of {MaxHeight}";
        }
    }
    class LandTransport : Transport
    {
        public int Wheels { get; set; }
        public void Land()
        {
            Console.WriteLine("Driving on Land...");
        }
        public override string ToString()
        {
            return $"car {base.ToString()} and {Wheels} wheels";
        }
    }
    class AquaticTransport : Transport
    {
        public void Navigate()
        {
            Console.WriteLine("Navigating...");
        }
        public override string ToString()
        {
            return $"boat {base.ToString()}";
        }
    }
}
