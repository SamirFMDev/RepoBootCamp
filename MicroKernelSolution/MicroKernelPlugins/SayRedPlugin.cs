using MicroKernelContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroKernelPlugins
{
    class SayRedPlugin : IPlugin
    {        
        public void MakeSomething()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("I'm a plugin");
            Console.ResetColor();
        }
        
    }
}
