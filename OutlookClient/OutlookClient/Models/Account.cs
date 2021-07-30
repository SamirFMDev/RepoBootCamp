using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookClient.Models
{
    public class Account : IAccount
    {
        protected string IP { get; set; }
        protected string Direction { get; set; }
        protected List<Rules> Rules { get; set; }
        protected List<Folder> Folders { get; set; }
        private string[] DefaultFolders = new[] { "Send", "Inbox" };

        public Account(string IP, string Direction)
        {
            this.IP = IP;
            this.Direction = Direction;
            Rules = new();
            Folders = new();

            foreach (string defaultFolder in DefaultFolders)
                AddFolder(new Folder(defaultFolder, true));
        }

        public string GetIP() => IP;
        public string GetDirection() => Direction;
        public Folder GetFolder(string name)
            => Folders
                .Where(folder => folder.GetName() == name)
                .FirstOrDefault();
        public List<Folder> GetFolders() => Folders;
        public void AddFolder(Folder folder) => Folders.Add(folder);
        public void RemoveFolder(Folder folder) => Folders.Remove(folder);
    }
}
