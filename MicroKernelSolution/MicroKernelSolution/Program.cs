using MicroKernelContract;
using System.Collections.Generic;

namespace MicroKernelSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Kernel application");
            ICollection<IPlugin> plugins = PluginFactory.GetPlugins();

            foreach (var plug in plugins) {
                plug.MakeSomething();
            }
        }
    }
}
