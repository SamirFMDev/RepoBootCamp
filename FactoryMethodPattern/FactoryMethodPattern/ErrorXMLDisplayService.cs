using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    class ErrorXMLDisplayService : DisplayService
    {
        protected override XMLParser getParser()
        {
            return new ErrorXMLParser();
        }
    }
}
