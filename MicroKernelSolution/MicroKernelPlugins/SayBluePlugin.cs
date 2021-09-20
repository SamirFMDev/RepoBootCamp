using MicroKernelContract;
using System;

namespace MicroKernelPlugins
{
    public class SayBluePlugin : IPlugin
    {
        public void MakeSomething()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("I'm a plugin");
            Console.ResetColor();
        }
    }
}
