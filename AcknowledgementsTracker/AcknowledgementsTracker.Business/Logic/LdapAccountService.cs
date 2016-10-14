namespace AcknowledgementsTracker.Business.Logic
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class LdapAccountService
    {
        public string GetUserName()
        {
            return LdapAccountManager.Instance.GetUserName();
        }

        public string GetUserEmail()
        {
            return LdapAccountManager.Instance.GetUserEmail();
        }

        public IUser GetUserData()
        {
            return LdapAccountManager.Instance.GetUserData();
        }

        public IEnumerable<IUser> GetAllUsersData()
        {
            return LdapAccountManager.Instance.GetAllUsersData();
        }
    }
}
