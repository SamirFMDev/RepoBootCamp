using System;
using System.Reflection;
using System.Linq;
using ReflectionLibrary;

namespace Reflection
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program started");

            Assembly assembly = null;
            try
            {
                assembly = Assembly.Load("ReflectionLibrary");
                FindTypes(assembly);

                Type myClass2 = assembly.GetType("ReflectionLibrary.MyClass2");
                object obj = Activator.CreateInstance(myClass2, new object[] { "Dwight", 36 });
                Console.WriteLine(obj);

                MethodInfo getAge = myClass2.GetMethod("GetAge");
                Console.WriteLine(getAge.Invoke(obj, null));

                MethodInfo getMessage = myClass2.GetMethod("GetMessage");
                Console.WriteLine(getMessage.Invoke(obj, new object[] { "Pepe" }));

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Assembly no encontrado {ex}");
            }
        }
        static void FindTypes(Assembly assembly)
        {
            if (assembly != null)
            {
                Console.WriteLine("Lost tipos encontrados en {0} son:", assembly.FullName);

                Type[] types = assembly.GetTypes();
                foreach (Type type in types)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Clase:");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(type.Name);

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Methods:");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    foreach (var method in type.GetMethods())
                    {
                        Console.WriteLine(method.Name);
                    }

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Properties:");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    foreach (var prop in type.GetProperties())
                    {
                        Console.WriteLine(prop.Name);
                    }
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
