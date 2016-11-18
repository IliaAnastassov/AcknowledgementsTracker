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

            SearchResult result;
            try
            {
                result = searcher.FindOne();
            }
            catch (ArgumentException)
            {
                throw new Exception("User not found");
            }

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

        public string GetUserUsername(string fullName)
        {
            string username = string.Empty;
            var searcher = new DirectorySearcher(ldapConnection.SearchRoot);
            try
            {
                searcher.Filter = $"(&(givenName={fullName.Split()[0]})(sn={fullName.Split()[1]}))";
            }
            catch (IndexOutOfRangeException)
            {
                throw new ArgumentException("Please use the provided form: Firstname Lastname");
            }

            var searchedProperty = "uid";
            searcher.PropertiesToLoad.Add(searchedProperty);

            SearchResult result;
            try
            {
                result = searcher.FindOne();
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("User not found");
            }

            if (result != null)
            {
                foreach (var resultCollection in result.Properties[searchedProperty])
                {
                    username = resultCollection.ToString();
                }
            }
            else
            {
                throw new ArgumentException("User not found");
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

            SearchResult result;
            try
            {
                result = searcher.FindOne();
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("User not found");
            }

            if (result != null)
            {
                foreach (var resultCollection in result.Properties[searchedProperty])
                {
                    email = resultCollection.ToString();
                }
            }

            return email;
        }

        public IEnumerable<string> GetAllUsernames(string search)
        {
            List<string> usernames = new List<string>();
            var searcher = new DirectorySearcher(ldapConnection.RootEntry);
            searcher.Filter = $"(|(uid=*{search}*)(givenName=*{search}*)(sn=*{search}*)(displayName=*{search}*)(cn=*{search}*))";

            var searchedProperty = "uid";
            searcher.PropertiesToLoad.Add(searchedProperty);

            SearchResultCollection results;
            try
            {
                results = searcher.FindAll();
            }
            catch (ArgumentException)
            {
                throw new Exception("User not found");
            }

            if (results != null)
            {
                foreach (SearchResult result in results)
                {
                    foreach (var resultCollection in result.Properties[searchedProperty])
                    {
                        usernames.Add(resultCollection.ToString());
                    }
                }
            }

            return usernames;
        }

        public IEnumerable<IUser> GetUsers(string search)
        {
            List<User> users = new List<User>();
            var searcher = new DirectorySearcher(ldapConnection.RootEntry);
            searcher.Filter = $"(|(uid=*{search}*)(givenName=*{search}*)(sn=*{search}*)(displayName=*{search}*)(cn=*{search}*)(description=*{search}*))";

            var usernameProperty = "uid";
            var givenNameProperty = "givenName";
            var surnameProperty = "sn";
            var mailProperty = "mail";
            var teamProperty = "description";
            searcher.PropertiesToLoad.AddRange(new string[] { usernameProperty, givenNameProperty, surnameProperty, mailProperty, teamProperty });

            SearchResultCollection results;
            try
            {
                results = searcher.FindAll();
            }
            catch (ArgumentException)
            {
                throw new Exception("User not found");
            }

            if (results != null)
            {
                foreach (SearchResult result in results)
                {
                    string username = null,
                           firstname = null,
                           lastname = null,
                           email = null,
                           team = null;

                    foreach (var resultCollection in result.Properties[usernameProperty])
                    {
                        username = resultCollection.ToString();
                    }

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
                        email = resultCollection.ToString();
                    }

                    foreach (var resultColleciton in result.Properties[teamProperty])
                    {
                        team = resultColleciton.ToString();
                    }

                    // Check explicitly for first name AND last name AND proxiad email
                    if (email != null && email.Contains("proxiad") && firstname != null && lastname != null)
                    {
                        var user = new User(username, $"{firstname} {lastname}", email, team);
                        users.Add(user);
                    }
                }
            }

            // Return list ordered alphabetically
            return users.OrderBy(u => u.Name).ToList();
        }

        public IUser GetUserData(string username)
        {
            var firstname = string.Empty;
            var lastname = string.Empty;
            var email = string.Empty;
            string team = string.Empty;
            var searcher = new DirectorySearcher(ldapConnection.SearchRoot);
            searcher.Filter = $"(uid={username})";

            var givenNameProperty = "givenName";
            var surnameProperty = "sn";
            var mailProperty = "mail";
            var teamProperty = "description";

            searcher.PropertiesToLoad.AddRange(new string[] { givenNameProperty, surnameProperty, mailProperty, teamProperty });

            SearchResult result;
            try
            {
                result = searcher.FindOne();
            }
            catch (ArgumentException)
            {
                throw new Exception("User not found");
            }

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
                    email = resultCollection.ToString();
                }

                foreach (var resultCollection in result.Properties[teamProperty])
                {
                    team = resultCollection.ToString();
                }
            }

            return new User(username, $"{firstname} {lastname}", email, team);
        }

        public IEnumerable<IUser> GetAllUsersData()
        {
            List<User> users = new List<User>();
            var searcher = new DirectorySearcher(ldapConnection.SearchRoot);

            var usernameProperty = "uid";
            var givenNameProperty = "givenName";
            var surnameProperty = "sn";
            var mailProperty = "mail";
            var teamProperty = "description";

            searcher.PropertiesToLoad.AddRange(new string[] { usernameProperty, givenNameProperty, surnameProperty, mailProperty, teamProperty });

            SearchResultCollection results;
            try
            {
                results = searcher.FindAll();
            }
            catch (ArgumentException)
            {
                throw new Exception("User not found");
            }

            if (results != null)
            {
                foreach (SearchResult result in results)
                {
                    string username = null,
                           firstname = null,
                           lastname = null,
                           email = null,
                           team = null;

                    foreach (var resultCollection in result.Properties[usernameProperty])
                    {
                        username = resultCollection.ToString();
                    }

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
                        email = resultCollection.ToString();
                    }

                    foreach (var resultCollection in result.Properties[teamProperty])
                    {
                        team = resultCollection.ToString();
                    }

                    // Check explicitly for first name AND last name AND proxiad email
                    if (email != null && email.Contains("proxiad") && firstname != null && lastname != null)
                    {
                        var user = new User(username, $"{firstname} {lastname}", email, team);
                        users.Add(user);
                    }
                }
            }

            // Order by name
            return users.OrderBy(u => u.Name).ToList();
        }
    }
}
