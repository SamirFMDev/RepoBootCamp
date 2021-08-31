using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    class OrderXMLParser : XMLParser
    {
        public string parse()
        {
            Console.WriteLine("Parsing order XML...");
            return "Order XML Message";
        }
    }
}
