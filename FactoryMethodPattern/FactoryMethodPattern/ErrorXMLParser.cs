using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    class ErrorXMLParser : XMLParser
    {
        public string parse()
        {
            Console.WriteLine("Parsing error XML...");
            return "Error XML Message";
        }
    }
}
