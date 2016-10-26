namespace AcknowledgementsTracker.Business.Interfaces
{
    using System.Collections.Generic;

    public interface ILdapAccountManager
    {
        void Setup(ILdapServerConnection ldapConnection);

        void Destroy();

        string GetUserFullName(string username);

        string GetUserUsername(string fullName);

        IEnumerable<string> GetAllUsernames(string name);

        string GetUserEmail();

        IEnumerable<IUser> GetAllUsersData();
    }
}
