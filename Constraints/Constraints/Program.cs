using System;

namespace Constraints
{
    public class UniqueInstance<T> where T: new()
    {
        public UniqueInstance(){ }

        //public static T Unique = new();
        public static T Unique { get; } =( Unique == null ? new(): Unique);
    }
    public class Person : UniqueInstance<Person>
    {
        public string Name;
        public string LastName;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person.Unique.Name = "pepe";
            Person.Unique.LastName = "suarez";
            Console.WriteLine(Person.Unique.Name);
        }
    }
}
