using System;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {

            int a, b;
            char c, d;
            a = 10;
            b = 20;
            c = 'I';
            d = 'V';

            Console.WriteLine("Before calling swap");
            Console.WriteLine("a = {0}, b = {1}", a, b);
            Console.WriteLine("c = {0}, b = {1}", c, d);

            Swap<int>(ref a, ref b);
            Swap<char>(ref c, ref d);

            Console.WriteLine("After calling swap");
            Console.WriteLine("a = {0}, b = {1}", a, b);
            Console.WriteLine("c = {0}, b = {1}", c, d);
        }
        static void Swap<T>(ref T a1, ref T b1)
        {
            T temp = a1;
            a1 = b1;
            b1 = temp;
        }
    }
}
