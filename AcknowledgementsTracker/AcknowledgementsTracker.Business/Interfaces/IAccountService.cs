namespace AcknowledgementsTracker.Business.Interfaces
{
    using System.Collections.Generic;

    public interface IAccountService
    {
        string ReadUserFullName(string username);

        /// <summary>
        /// Gets the username of the user by user's full name
        /// </summary>
        /// <param name="fullname"></param>
        /// <returns></returns>
        string ReadUserUsername(string fullname);

        IEnumerable<string> ReadAllUsernames(string name);

        string ReadUserEmail();

        IUser ReadUserData(string username);

        IEnumerable<IUser> ReadAllUsersData();

        void SetAccountManager(ILdapServerConnection ldapConnection);
    }
}
