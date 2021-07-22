using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionLibrary
{
    public class MyClass2
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public MyClass2(string name, int age)
        {
            if (String.IsNullOrEmpty(name)) throw new ArgumentNullException("name");

            this.Name = name;
            this.Age = age;
        }

        public string GetAge()
        {
            return $"{Name}, you are {this.Age} years old";
        }

        public string GetMessage(string name)
        {
            return $"Hello {name} from {this.Name}";
        }
    }
}
