using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>()
            {
                new Product() { ID = 1, Price = 35 },
                new Product() { ID = 1, Price = 150 },
                new Product() { ID = 1, Price = 650 },
                new Product() { ID = 1, Price = 150 },
                new Product() { ID = 1, Price = 15 },
                new Product() { ID = 1, Price = 35 },
                new Product() { ID = 1, Price = 650 },
                new Product() { ID = 1, Price = 78 },
                new Product() { ID = 1, Price = 35 },
                new Product() { ID = 1, Price = 78 }
            };

            Console.WriteLine($"Average: {products.Average(p => p.Price)}");
            Console.WriteLine($"Median: {products.Median(p => p.Price)}");

            //The most common number
            Console.WriteLine($"Mode: {products.Mode(p => p.Price)}");
            //The less common number
            Console.WriteLine($"UnMode: {products.UnMode(p => p.Price)}");
        }

        public static bool MoreThanFor(string name)
        {
            return name.Length > 4;
        }

        public static Exception[] GetExceptions()
        {
            return new Exception[]
            {
                new ArgumentException(),
                new SystemException(),
                new IndexOutOfRangeException(),
                new InvalidOperationException(),
                new NullReferenceException(),
                new InvalidCastException(),
                new DivideByZeroException(),
                new ApplicationException(),
                new OverflowException()
            };
        }

        public static void ShowArray(IEnumerable<string> group, string description)
        {
            Console.WriteLine("{0} {1}", description, string.Join(", ", group.ToArray()));
        }
    }
}
