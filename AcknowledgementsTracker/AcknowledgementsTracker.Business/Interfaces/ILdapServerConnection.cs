namespace AcknowledgementsTracker.Business.Interfaces
{
    using System.DirectoryServices;

    public interface ILdapServerConnection
    {
        string Username { get; set; }

        DirectoryEntry RootEntry { get; }

        bool IsAuthenticated();
    }
}
