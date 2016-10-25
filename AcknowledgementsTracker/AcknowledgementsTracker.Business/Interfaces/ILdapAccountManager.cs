namespace AcknowledgementsTracker.Business.Interfaces
{
    using System.Collections.Generic;

    public interface ILdapAccountManager
    {
        void Setup(ILdapServerConnection ldapConnection);

        void Destroy();

        string GetUserFullName(string username);

        string GetUsername(string fullName);

        string GetUserEmail();

        IEnumerable<IUser> GetAllUsersData();
    }
}
