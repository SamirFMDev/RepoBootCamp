using System;
using System.Collections.Generic;

namespace ValueTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            var n1 = new DetailedInteger(0);
            n1.AddDetail("A");
            Console.WriteLine(n1);

            var n2 = n1;
            n2.Number = 7;
            n2.AddDetail("B");

            Console.WriteLine(n1);
            Console.WriteLine(n2);
        }
    }

    internal struct DetailedInteger
    {
        public int Number;
        public List<string> Details;

        public DetailedInteger(int Number)
        {
            this.Number = Number;
            this.Details = new List<string>();
        }

        public void AddDetail(string detail)
        {
            Details.Add(detail);
        }

        public override string ToString()
        {
            //string resultado = "";
            ////foreach(string detail in Details)
            ////{
            ////    resultado += Number + " " + detail + ", ";
            ////}
            //resultado = Number + " " + String.Join(", ", Details);
            return Number + " " + String.Join(", ", Details);
        }
    }
}
