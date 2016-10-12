namespace AcknowledgementsTracker.Business.Interfaces
{
    public interface ILdapManager
    {
        bool ValidateUser(string username, string password);

        string GetUserFullname(string baseDn, string username);

        string GetUserEmail(string baseDn, string username);
    }
}
