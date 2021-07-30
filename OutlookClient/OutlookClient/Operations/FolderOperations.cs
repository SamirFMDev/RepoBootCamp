using OutlookClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookClient
{
    public static class FolderOperations
    {
        public static Folder CreateFolder(Account account, string name)
        {
            Folder folder = new Folder(name, false);

            if (account.GetFolder(name) != null)
            {
                Console.WriteLine($"Folder {name} alredy exists.\n");
                return null;
            }

            account.AddFolder(folder);
            Console.WriteLine($"Folder {name} created successfully.\n");
            return folder;
        }

        public static void DeleteFolder(Account account, string name)
        {
            Folder folder = account.GetFolder(name);
            if (folder == null)
            {
                Console.WriteLine($"Folder {name} doesn't exist.\n");
                return;
            }
            else if (folder.GetDefault())
            {
                Console.WriteLine($"Folder {name} can't be deleted.\n");
                return;
            }
            account.RemoveFolder(folder);
            Console.WriteLine($"Folder {name} deleted successfully.\n");
        }
    }
}
