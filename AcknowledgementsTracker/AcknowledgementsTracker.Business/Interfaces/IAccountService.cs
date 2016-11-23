namespace AcknowledgementsTracker.Business.Interfaces
{
    using System.Collections.Generic;

    public interface IAccountService
    {
        string ReadUserFullName(string username);

        string ReadUserUsername(string fullname);

        IEnumerable<string> ReadAllUsernames(string name);

        string ReadUserEmail();

        IUser ReadUserData(string username);

        IEnumerable<IUser> ReadAllUsersData();
    }
}
