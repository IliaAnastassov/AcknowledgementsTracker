namespace AcknowledgementsTracker.Business.Logic
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class LdapAccountService : IAccountService
    {
        private IAccountManager ldapAccountManager;

        public void SetAccountManager(ILdapServerConnection ldapConnection)
        {
            ldapAccountManager = new LdapAccountManager(ldapConnection);
        }

        public string ReadUserFullName(string username)
        {
            return ldapAccountManager.GetUserFullName(username);
        }

        public string ReadUserUsername(string fullname)
        {
            return ldapAccountManager.GetUserUsername(fullname);
        }

        public IEnumerable<string> ReadAllUsernames(string name)
        {
            return ldapAccountManager.GetAllUsernames(name);
        }

        public string ReadUserEmail()
        {
            return ldapAccountManager.GetUserEmail();
        }

        public IUser ReadUserData(string username)
        {
            return ldapAccountManager.GetUserData(username);
        }

        public IEnumerable<IUser> ReadAllUsersData()
        {
            return ldapAccountManager.GetAllUsersData();
        }
    }
}
