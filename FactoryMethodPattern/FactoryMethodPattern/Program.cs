using System;

namespace FactoryMethodPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayService service;

            service = new FeedbackXMLDisplayService();
            service.display();

            service = new ErrorXMLDisplayService();
            service.display();

            service = new OrderXMLDisplayService();
            service.display();

            service = new ResponseXMLDisplayService();
            service.display();
        }
    }
}
