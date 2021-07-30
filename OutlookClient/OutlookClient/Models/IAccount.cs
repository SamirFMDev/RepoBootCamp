using System.Collections.Generic;

namespace OutlookClient.Models
{
    public interface IAccount
    {
        string GetIP();
        string GetDirection();
        void AddFolder(Folder folder);
        void RemoveFolder(Folder folder);
        Folder GetFolder(string name);
        List<Folder> GetFolders();
    }
}