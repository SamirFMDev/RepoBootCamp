using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookClient.Models
{
    public class Mail : IMail
    {
        protected string IPOrigen { get; set; }
        protected string From { get; set; }
        protected string Address { get; set; }
        protected string[] CarbonCopy { get; set; }
        protected string Subject { get; set; }
        protected string Body { get; set; }
        protected DateTime Date { get; set; }

        public Mail(string IPOrigen, string From, string Address, string[] CarbonCopy, string Subject, string Body)
        {
            this.IPOrigen = IPOrigen;
            this.From = From;
            this.Address = Address;
            this.CarbonCopy = CarbonCopy;
            this.Subject = Subject;
            this.Body = Body;
            Date = DateTime.Now;
        }

        public string[] GetReceivers() => new string[] { Address }.Concat(CarbonCopy).ToArray();
        public string GetSubject() => Subject;
        public string GetBody() => Body;
    }
}
