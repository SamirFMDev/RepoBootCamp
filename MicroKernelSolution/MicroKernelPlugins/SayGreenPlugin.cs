using MicroKernelContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroKernelPlugins
{
    public class SayGreenPlugin : IPlugin
    {
        public void MakeSomething()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("I'm a plugin");
            Console.ResetColor();
        }
    }
}
