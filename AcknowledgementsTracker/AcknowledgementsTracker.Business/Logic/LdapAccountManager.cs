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
        private string username;
        private PrincipalContext context;
        private static LdapAccountManager instance;

        public static LdapAccountManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LdapAccountManager();
                }
                return instance;
            }
        }

        private LdapAccountManager()
        {
        }

        public void Setup(string domainName, string username, string password)
        {
            var userId = $"uid={username},ou=People,dc=proxiad,dc=bg";
            context = new PrincipalContext(ContextType.Domain, "ldap.proxiad.corp/dc=proxiad,dc=bg");
            this.username = username;
        }

        public void Destroy()
        {
            if (instance != null)
            {
                instance = null;
            }
        }

        public string GetUserName()
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

        public string GetUserEmail()
        {
            UserPrincipal queryFilter = new UserPrincipal(context);
            queryFilter.SamAccountName = username;
            UserPrincipal result;

            using (var searcher = new PrincipalSearcher(queryFilter))
            {
                result = (UserPrincipal)searcher.FindOne();
            }

            return result.EmailAddress;
        }

        public IEnumerable<IUser> GetAllUsersData()
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
