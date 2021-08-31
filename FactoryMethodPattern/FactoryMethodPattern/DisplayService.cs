using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    abstract class DisplayService
    {
        public void display()
        {
            XMLParser parser = getParser();
            string msg = parser.parse();
            Console.WriteLine(msg);
        }

        protected abstract XMLParser getParser();
    }
}
