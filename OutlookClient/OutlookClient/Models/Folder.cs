using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookClient.Models
{
    public class Folder : IFolder
    {
        protected string Name { get; set; }
        protected bool IsDefault { get; set; }
        protected List<Mail> Mails { get; set; }

        public Folder(string Name, bool IsDefault)
        {
            this.Name = Name;
            this.IsDefault = IsDefault;
            Mails = new();
        }

        public string GetName() => Name;
        public bool GetDefault() => IsDefault;
        public Mail GetMail(string subject) 
            => Mails
                .Where(mail => mail.GetSubject() == subject)
                .FirstOrDefault();
        public List<Mail> GetMails() => Mails;
        public void AddMail(Mail mail) => Mails.Add(mail);
        public void RemoveMail(Mail mail) => Mails.Remove(mail);
    }
}
