﻿using System;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Expresion expresion = new(20, 10);
            var result = expresion.ApllyOperator(Expresion.Operation.Multiply);
            Console.WriteLine($"Result: {result}");
        }
    }
}
