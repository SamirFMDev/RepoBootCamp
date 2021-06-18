using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = Fibonacci(10);
            Console.WriteLine(result);
            Console.ReadKey(true);
        }
        static string Fibonacci(int n)
        {
            string result = "";
            int n1 = 0;
            int n2 = 1;
            int sum;

            for (int i = 0; i < n; i++)
            {
                result += $"{ n1 } ";
                sum = n1 + n2;
                n1 = n2;
                n2 = sum;
                
            }

            return result;
        }
    }
}
