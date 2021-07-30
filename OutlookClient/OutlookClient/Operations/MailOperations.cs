using OutlookClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookClient
{
    public static class MailOperations
    {
        public static Mail SendMail(Account account, string address, string[] carbonCopy, string subject, string body)
        {
            Mail mail = new Mail(
                    account.GetIP(),
                    account.GetDirection(),
                    address,
                    carbonCopy,
                    subject,
                    body
                );
            account.GetFolder("Send").AddMail(mail);
            Console.WriteLine($"{account.GetDirection()}:");
            Console.WriteLine($"Mail send successfully.\n");
            return mail;
        }
        public static void ReceiveMail(Account account, Mail mail)
        {
            account.GetFolder("Inbox").AddMail(mail);
            Console.WriteLine($"{account.GetDirection()}:");
            Console.WriteLine($"Mail received '{mail.GetSubject()}': '{mail.GetBody()}'\n");
        }

        public static void MoveMail(Account account, string subject, string originFolderName, string destinationFolderName)
        {
            Folder originFolder = account.GetFolder(originFolderName);
            if (originFolder == null)
            {
                Console.WriteLine($"Can't move mail from non-existing folder '{originFolderName}'.\n");
                return;
            }
            Folder destinationFolder = account.GetFolder(destinationFolderName);
            if (destinationFolder == null)
            {
                Console.WriteLine($"Can't move mail to non-existing folder '{destinationFolderName}'.\n");
                return;
            }
            Mail mail = originFolder.GetMail(subject);
            if (mail == null)
            {
                Console.WriteLine($"Can't move non-existing mail '{subject}'.\n");
                return;
            }
            destinationFolder.AddMail(mail);
            originFolder.RemoveMail(mail);
            Console.WriteLine($"Mail '{subject}' moved successfully.\n");
        }

        public static void RemoveMail(Account account, string subject, string originFolderName)
        {
            Folder originFolder = account.GetFolder(originFolderName);
            if (originFolder == null)
            {
                Console.WriteLine($"Can't remove mail from non-existing folder '{originFolderName}'.\n");
                return;
            }
            Mail mail = originFolder.GetMail(subject);
            if(mail == null)
            {
                Console.WriteLine($"Can't remove non-existing mail '{subject}'.\n");
                return;
            }
            originFolder.RemoveMail(mail);
            Console.WriteLine($"Mail '{subject}' removed successfully.\n");
        }
    }
}
