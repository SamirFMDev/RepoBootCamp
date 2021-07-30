using OutlookClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OutlookClient
{
    class Program
    {
        public static List<Account> accounts;
        static void Main(string[] args)
        {
            accounts = new()
            {
                new("10.0.0.1", "el.barto@asd.com"),
                new("10.0.0.2", "moe.Szyslak@asd.com"),
                new("10.0.0.2", "homero.simpson@asd.com")
            };
            SMTP smtp = new SMTP(new(accounts));

            smtp.SendMail("el.barto@asd.com", 
                "moe.Szyslak@asd.com", new string[] { },
                "Busco a Mos",
                "Esta Mos?, Mos Ebrios");

            smtp.SendMail("el.barto@asd.com", 
                "moe.Szyslak@asd.com", new string[] { }, 
                "Busco a un amigo en la taberna", 
                "Se apellida Hugh, primer nombre Jass");

            Account elbarto = smtp.GetAccount("el.barto@asd.com");
            FolderOperations.CreateFolder(elbarto, "Pranks");
            MailOperations.MoveMail(elbarto, "Error nombre", "Send", "Pranks");
            MailOperations.MoveMail(elbarto, "Busco a Mos", "Send", "Pranks");
            MailOperations.MoveMail(elbarto, "Busco a un amigo en la taberna", "Send", "Pranks");

            smtp.SendMail("moe.Szyslak@asd.com", 
                "el.barto@asd.com", new string[] { "homero.simpson@asd.com", "error@mail" }, 
                "Cuidate gusano", 
                "Si te llego a encontrar...");

            smtp.SendMail("moe.Szyslak@asd.com", 
                "homero.simpson@asd.com", new string[] { }, 
                "Mensaje equivocado?", 
                "Lo siento Homero te envie el mail con CC, pero si no pagas tu cuenta...");

            smtp.SendMail("homero.simpson@asd.com",
                "moe.Szyslak@asd.com", new string[] { },
                "Homero?",
                "Ay quien es Homero, yo soy Cosme Fulanito...");

            printAccounts();

            Account homero = smtp.GetAccount("homero.simpson@asd.com");
            FolderOperations.DeleteFolder(homero, "Send");
            MailOperations.RemoveMail(homero, "Homero?", "Send");
            printAccount(homero);
            FolderOperations.DeleteFolder(elbarto, "Pranks");
            printAccount(elbarto);
        }
        public static void printMails(Folder folder)
        {
            foreach (Mail mail in folder.GetMails())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\t{mail.GetSubject()}");
            }
        }

        public static void printFolders(Account account)
        {
            foreach (Folder folder in account.GetFolders())
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Folder {folder.GetName()}");
                printMails(folder);
            }
        }
        public static void printAccount(Account account)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Account: {account.GetDirection()}");
            printFolders(account);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void printAccounts()
        {
            Console.WriteLine("\n\nPrinting accounts...");
            foreach (Account account in accounts)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Account: {account.GetDirection()}");
                printFolders(account);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n");
        }
    }
}
