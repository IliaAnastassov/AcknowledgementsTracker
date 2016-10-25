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

        public string GetUserFullName(string username)
        {
            string firstname = string.Empty;
            string lastname = string.Empty;
            var searcher = new DirectorySearcher(ldapConnection.SearchRoot);
            searcher.Filter = $"(uid={username})";

            var givenNameProperty = "givenName";
            var surnameProperty = "sn";
            searcher.PropertiesToLoad.Add(givenNameProperty);
            searcher.PropertiesToLoad.Add(surnameProperty);

            var result = searcher.FindOne();

            if (result != null)
            {
                foreach (var resultCollection in result.Properties[givenNameProperty])
                {
                    firstname = resultCollection.ToString();
                }

                foreach (var resultCollection in result.Properties[surnameProperty])
                {
                    lastname = resultCollection.ToString();
                }
            }

            return $"{firstname} {lastname}";
        }

        // TODO: Fix the search filter
        public string GetUsername(string fullName)
        {
            string username = string.Empty;
            var searcher = new DirectorySearcher(ldapConnection.SearchRoot);
            searcher.Filter = $"((givenName={fullName.Split()[0]})(sn={fullName.Split()[1]}))";

            var searchedProperty = "uid";
            searcher.PropertiesToLoad.Add(searchedProperty);

            var result = searcher.FindOne();

            if (result != null)
            {
                foreach (var resultCollection in result.Properties[searchedProperty])
                {
                    username = resultCollection.ToString();
                }
            }

            return username;
        }

        public string GetUserEmail()
        {
            string email = string.Empty;
            var searcher = new DirectorySearcher(ldapConnection.SearchRoot);
            searcher.Filter = $"(uid={ldapConnection.Username})";

            var searchedProperty = "mail";
            searcher.PropertiesToLoad.Add(searchedProperty);

            var result = searcher.FindOne();

            if (result != null)
            {
                foreach (var resultCollection in result.Properties[searchedProperty])
                {
                    email = resultCollection.ToString();
                }
            }

            return email;
        }

        public IUser GetUserData(string username)
        {
            User user = new User();
            string firstname = string.Empty;
            string lastname = string.Empty;
            var searcher = new DirectorySearcher(ldapConnection.SearchRoot);
            searcher.Filter = $"(uid={username})";

            var givenNameProperty = "givenName";
            var surnameProperty = "sn";
            var mailProperty = "mail";

            searcher.PropertiesToLoad.AddRange(new string[] { givenNameProperty, surnameProperty, mailProperty });

            var result = searcher.FindOne();

            if (result != null)
            {
                foreach (var resultCollection in result.Properties[givenNameProperty])
                {
                    firstname = resultCollection.ToString();
                }

                foreach (var resultCollection in result.Properties[surnameProperty])
                {
                    lastname = resultCollection.ToString();
                }

                foreach (var resultCollection in result.Properties[mailProperty])
                {
                    user.Email = resultCollection.ToString();
                }
            }

            user.Name = $"{firstname} {lastname}";

            return user;
        }

        public IEnumerable<IUser> GetAllUsersData()
        {
            List<User> users = new List<User>();
            string firstname = string.Empty;
            string lastname = string.Empty;
            var searcher = new DirectorySearcher(ldapConnection.SearchRoot);

            var givenNameProperty = "givenName";
            var surnameProperty = "sn";
            var mailProperty = "mail";

            searcher.PropertiesToLoad.AddRange(new string[] { givenNameProperty, surnameProperty, mailProperty });

            var results = searcher.FindAll();

            if (results != null)
            {
                foreach (SearchResult result in results)
                {
                    var user = new User();

                    foreach (var resultCollection in result.Properties[givenNameProperty])
                    {
                        firstname = resultCollection.ToString();
                    }

                    foreach (var resultCollection in result.Properties[surnameProperty])
                    {
                        lastname = resultCollection.ToString();
                    }

                    foreach (var resultCollection in result.Properties[mailProperty])
                    {
                        user.Email = resultCollection.ToString();
                    }

                    // Set the full name of the user
                    user.Name = $"{firstname} {lastname}";

                    if (user.Email != null && user.Name != null)
                    {
                        users.Add(user);
                    }
                }
            }

            return users;
        }
    }
}
