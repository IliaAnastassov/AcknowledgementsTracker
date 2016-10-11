namespace AcknowledgementsTracker.Business.Interfaces
{
    public interface ILdapManager
    {
        bool ValidateUser(string username, string password);
    }
}
