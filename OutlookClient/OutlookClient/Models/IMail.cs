namespace OutlookClient.Models
{
    public interface IMail
    {
        string[] GetReceivers();
        string GetSubject();
        string GetBody();
    }
}