namespace AcknowledgementsTracker.Business.Interfaces
{
    using System.Collections.Generic;

    public interface ILdapAccountService
    {
        string ReadUserFullName(string username);

        string ReadUsername(string fullname);

        string ReadUserEmail();

        IUser ReadUserData(string username);

        IEnumerable<IUser> ReadAllUsersData();
    }
}
