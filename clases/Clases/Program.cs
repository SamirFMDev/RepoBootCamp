using System;

namespace Clases
{
    class Program
    {
        static void Main(string[] args)
        {
            Toyota toyota = new Toyota();
            Console.WriteLine(toyota.ToString());
            toyota.DriveLand();

            Console.WriteLine("\n");
            ElectricFlyingCar electricFlyingCar = new ElectricFlyingCar();
            Console.WriteLine(electricFlyingCar.ToString());
            electricFlyingCar.Fly();
            electricFlyingCar.Land();
            electricFlyingCar.DriveLand();

            Console.WriteLine("\n");
            Boat boat = new Boat();
            Console.WriteLine(boat.ToString());
            boat.Navigate();

            Console.WriteLine("\n");
            Boeing boeing = new Boeing();
            Console.WriteLine(boeing.ToString());
            boeing.Land();
        }
    }

    abstract class Transport
    {
        public double SpeedLimit { get; set; }
        public int PeopleCapacity { get; set; }

        public override string ToString()
        {
            return $"can reach {SpeedLimit} km/h, with a capacity of {PeopleCapacity} persons";
        }
    }
    interface IAirTransport
    {
        double MaxHeight { get; set; }
        void Fly();
        void Land();
    }
    interface ILandTransport
    {
        int Wheels { get; set; }
        void DriveLand();
    }
    class AirTransport: Transport, IAirTransport
    {
        public double MaxHeight { get; set; }

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
    class LandTransport : Transport, ILandTransport
    {
        public int Wheels { get; set; }
        public void DriveLand()
        {
            Console.WriteLine("Driving on Land...");
        }
        public override string ToString()
        {
            return $"car {base.ToString()} and {Wheels} wheels";
        }
    }
    class AirLandTransport : Transport, IAirTransport, ILandTransport
    {
        AirTransport airTransport = new AirTransport();
        LandTransport landTransport = new LandTransport();

        public double MaxHeight { get; set; }
        public int Wheels { get; set; }

        public void Fly()
        {
            airTransport.Fly();
        }
        public void Land()
        {
            airTransport.Land();
        }

        public void DriveLand()
        {
            landTransport.DriveLand();
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
