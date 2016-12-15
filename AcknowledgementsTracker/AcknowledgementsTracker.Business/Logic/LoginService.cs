namespace AcknowledgementsTracker.Business.Logic
{
    using System;
    using Interfaces;
    using Ressources;

    public class LoginService : ILoginService
    {
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
                response.ResponseMessage = BusinessResources.InvalidInput;

                return response;
            }

            ldapConnection.Connect(settings);

            if (ldapConnection.IsAuthenticated)
            {
                ldapAccountService.SetAccountManager(ldapConnection);

                IUser user;

                if (ldapConnection.IsUIDPropertyUsed)
                {
                    user = ldapAccountService.ReadUserData(settings.Username);
                }
                else
                {
                    var username = ldapAccountService.ReadUserUsername(settings.Username);
                    user = ldapAccountService.ReadUserData(username);
                }

                response.User = user;
                response.ResponseMessage = BusinessResources.AuthenticationSucceded;
            }
            else
            {
                response.User = null;
                response.ResponseMessage = BusinessResources.AuthenticationFailed;
            }

            return response;
        }
    }
}
