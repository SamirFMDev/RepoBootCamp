using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionLibrary
{
    public class MyClass1
    {
        private readonly DateTime _dateStamp;

        public MyClass1()
        {
            this._dateStamp = DateTime.UtcNow;
        }

        public override string ToString()
        {
            return this._dateStamp.ToString("dd/MM/yyyy HH:mm:ss");
        }
    }
}
