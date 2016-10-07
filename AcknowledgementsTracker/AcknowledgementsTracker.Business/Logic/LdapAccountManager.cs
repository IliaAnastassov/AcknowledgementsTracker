namespace AcknowledgementsTracker.Business.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.DirectoryServices.AccountManagement;
    using System.Linq;
    using Entities;
    using Interfaces;

    public class LdapAccountManager
    {
        private PrincipalContext context;

        public LdapAccountManager(string domainName, string username, string password)
        {
            context = new PrincipalContext(ContextType.Domain, domainName, username, password);
        }

        public string GetUserName(string username)
        {
            UserPrincipal queryFilter = new UserPrincipal(context);
            queryFilter.SamAccountName = username;
            UserPrincipal result;

            using (var searcher = new PrincipalSearcher(queryFilter))
            {
                result = (UserPrincipal)searcher.FindOne();
            }

            return result.Name;
        }

        public IEnumerable<IUser> GetAllUserData()
        {
            UserPrincipal queryFilter = new UserPrincipal(context);
            var users = new List<User>();

            using (var searcher = new PrincipalSearcher(queryFilter))
            {
                foreach (UserPrincipal result in searcher.FindAll())
                {
                    var user = new User();
                    user.Email = result.EmailAddress;
                    user.Name = result.Name;

                    users.Add(user);
                }
            }

            return users;
        }
    }
}
