namespace AcknowledgementsTracker.Business.Interfaces
{
    using System.Collections.Generic;

    public interface IAccountManager
    {
        string GetUserFullName(string username);

        string GetUserUsername(string fullName);

        IEnumerable<string> GetAllUsernames(string name);

        string GetUserEmail();

        IUser GetUserData(string username);

        IEnumerable<IUser> GetAllUsersData();

        IEnumerable<IUser> GetUsers(string search);
    }
}
