using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    class ResponseXMLParser : XMLParser
    {
        public string parse()
        {
            Console.WriteLine("Parsing response XML...");
            return "Response XML Message";
        }
    }
}
