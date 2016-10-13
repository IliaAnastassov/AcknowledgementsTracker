namespace AcknowledgementsTracker.Business.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.DirectoryServices;
    using System.Linq;
    using Entities;
    using Interfaces;
    using System.Text;

    public class LdapAccountManager : ILdapAccountManager
    {
        private static LdapAccountManager instance;
        private ILdapServerConnection ldapConnection;

        // TODO: Review Singleton pattern
        protected LdapAccountManager()
        {
        }

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

        public static bool HasInstance()
        {
            if (instance != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Setup(ILdapServerConnection ldapConnection)
        {
            this.ldapConnection = ldapConnection;
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
            string fullName = string.Empty;
            var searcher = new DirectorySearcher(ldapConnection.RootEntry);
            searcher.Filter = $"(uid={ldapConnection.Username})";

            var searchedProperty = "cn";
            searcher.PropertiesToLoad.Add(searchedProperty);

            var result = searcher.FindOne();

            if (result != null)
            {
                foreach (object resultCollection in result.Properties[searchedProperty])
                {
                    fullName = resultCollection.ToString();
                }

                return fullName;
            }

            return null;
        }

        public string GetUserEmail()
        {
            string email = string.Empty;
            var searcher = new DirectorySearcher(ldapConnection.RootEntry);
            searcher.Filter = $"(uid={ldapConnection.Username})";

            var searchedProperty = "mail";
            searcher.PropertiesToLoad.Add(searchedProperty);

            var result = searcher.FindOne();

            if (result != null)
            {
                foreach (object resultCollection in result.Properties[searchedProperty])
                {
                    email = resultCollection.ToString();
                }

                return email;
            }

            return null;
        }

        public IUser GetUserData()
        {
            User user = new User();
            var searcher = new DirectorySearcher(ldapConnection.RootEntry);
            searcher.Filter = $"(uid={ldapConnection.Username})";

            var cnProperty = "cn";
            var mailProperty = "mail";

            searcher.PropertiesToLoad.Add(cnProperty);
            searcher.PropertiesToLoad.Add(mailProperty);

            var result = searcher.FindOne();

            if (result != null)
            {
                foreach (var resultCollection in result.Properties[cnProperty])
                {
                    user.Name = resultCollection.ToString();
                }

                foreach (var resultCollection in result.Properties[mailProperty])
                {
                    user.Email = resultCollection.ToString();
                }
            }

            return user;
        }

        public IEnumerable<IUser> GetAllUsersData()
        {
            List<User> users = new List<User>();
            var searcher = new DirectorySearcher(ldapConnection.RootEntry);

            var cnProperty = "cn";
            var mailProperty = "mail";

            searcher.PropertiesToLoad.Add(cnProperty);
            searcher.PropertiesToLoad.Add(mailProperty);

            var results = searcher.FindAll();

            if (results != null)
            {
                foreach (SearchResult result in results)
                {
                    var user = new User();

                    foreach (var resultCollection in result.Properties[cnProperty])
                    {
                        user.Name = resultCollection.ToString();
                    }

                    foreach (var resultCollection in result.Properties[mailProperty])
                    {
                        user.Email = resultCollection.ToString();
                    }

                    users.Add(user);
                }
            }

            return users;
        }
    }
}
