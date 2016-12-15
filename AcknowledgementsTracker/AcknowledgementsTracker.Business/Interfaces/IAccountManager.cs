namespace AcknowledgementsTracker.Business.Interfaces
{
    using System.Collections.Generic;

    public interface IAccountManager
    {
        void Destroy();

        string GetUserFullName(string username);

        string GetUserUsername(string fullName);

        IEnumerable<string> GetAllUsernames(string name);

        string GetUserEmail();

        IUser GetUserData(string username);

        IEnumerable<IUser> GetAllUsersData();
    }
}
