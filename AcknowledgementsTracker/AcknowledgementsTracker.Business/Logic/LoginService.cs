namespace AcknowledgementsTracker.Business.Logic
{
    using System;
    using Interfaces;

    public class LoginService : ILoginService
    {
        //var loginService = xxx;
        //loginService.Login(settings, ldapServerConnection, ldapAccountService);

        private ILdapServerConnection ldapConnection;
        private IAccountService ldapAccountService;
        private ILoginResponse response;

        public LoginService(ILdapServerConnection ldapConnection, IAccountService ldapAccountService)
        {
            this.ldapConnection = ldapConnection;
            this.ldapAccountService = ldapAccountService;
            response = new LoginResponse();
        }

        public ILoginResponse Login(ILdapSettingsService settings)
        {
            if (string.IsNullOrWhiteSpace(settings.Username)
                || string.IsNullOrWhiteSpace(settings.Password))
            {
                response.User = null;
                response.ErrorMessage = "Please fill all textboxes";

                return response;
            }

            ldapConnection.Connect(settings);

            if (ldapConnection.IsAuthenticated)
            {
                CreateAccountManager(ldapConnection);
            }

            IUser user = ldapAccountService.ReadUserData(settings.Username);

            if (user == null)
            {
                var username = ldapAccountService.ReadUserUsername(settings.Username);
                user = ldapAccountService.ReadUserData(username);
            }

            if (user != null)
            {
                response.User = user;
                response.ErrorMessage = string.Empty;
            }
            else
            {
                response.User = null;
                response.ErrorMessage = "Failed to authenticate. Please verify username and password";
            }

            return response;
        }

        private void CreateAccountManager(ILdapServerConnection connection)
        {
            IAccountManager ldapManager = LdapAccountManager.Instance;
            ldapManager.Setup(connection);
        }
    }
}
