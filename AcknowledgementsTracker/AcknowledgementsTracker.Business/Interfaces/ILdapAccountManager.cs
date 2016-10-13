namespace AcknowledgementsTracker.Business.Interfaces
{
    using System.Collections.Generic;

    public interface ILdapAccountManager
    {
        void Setup(ILdapServerConnection ldapConnection);

        void Destroy();

        string GetUserName();

        string GetUserEmail();

        IEnumerable<IUser> GetAllUsersData();
    }
}
