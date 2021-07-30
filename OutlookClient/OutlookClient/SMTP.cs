using OutlookClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookClient
{
    class SMTP
    {
        protected List<Account> Accounts { get; set; }
        public SMTP(List<Account> Accounts)
        {
            this.Accounts = Accounts;
        }
        public List<Account> GetAccounts() => Accounts;
        public Account GetAccount(string direction)
            => Accounts
                .Where(account => account.GetDirection() == direction)
                .FirstOrDefault();


        public void SendMail(string sender, string address, string[] carbonCopy, string subject, string body)
        {
            Mail mail = MailOperations.SendMail(GetAccount(sender), address, carbonCopy, subject, body);
            foreach(string mailReceiver in mail.GetReceivers())
            {
                Account receiver = GetAccount(mailReceiver);

                if(receiver == null)
                {
                    Console.WriteLine($"Can't reach address {mailReceiver}.\n");
                    return;
                }

                MailOperations.ReceiveMail(receiver, mail);
            }
        }
    }
}
