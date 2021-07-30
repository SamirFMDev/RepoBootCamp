using System.Collections.Generic;

namespace OutlookClient.Models
{
    public interface IFolder
    {
        string GetName();
        bool GetDefault();
        Mail GetMail(string subject);
        List<Mail> GetMails();
        void AddMail(Mail mail);
        void RemoveMail(Mail mail);   
    }
}