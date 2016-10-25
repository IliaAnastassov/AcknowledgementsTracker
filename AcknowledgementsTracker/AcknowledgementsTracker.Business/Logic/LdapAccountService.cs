namespace AcknowledgementsTracker.Business.Logic
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class LdapAccountService : ILdapAccountService
    {
        public string ReadUserFullName(string username)
        {
            return LdapAccountManager.Instance.GetUserFullName(username);
        }

        public string ReadUsername(string fullname)
        {
            return LdapAccountManager.Instance.GetUsername(fullname);
        }

        public string ReadUserEmail()
        {
            return LdapAccountManager.Instance.GetUserEmail();
        }

        public IUser ReadUserData(string username)
        {
            return LdapAccountManager.Instance.GetUserData(username);
        }

        public IEnumerable<IUser> ReadAllUsersData()
        {
            return LdapAccountManager.Instance.GetAllUsersData();
        }
    }
}
