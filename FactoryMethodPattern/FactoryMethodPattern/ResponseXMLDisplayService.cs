using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    class ResponseXMLDisplayService : DisplayService
    {
        protected override XMLParser getParser()
        {
            return new ResponseXMLParser();
        }
    }
}
