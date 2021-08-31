using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    class FeedbackXML : XMLParser
    {
        public string parse()
        {
            Console.WriteLine("Parsing feedback XML...");
            return "Feedback XML Message";
        }
    }
}
