namespace AcknowledgementsTracker.Presentation
{
    using System;
    using System.Threading;
    using System.Web;
    using System.Web.Configuration;
    using System.Web.Security;
    using System.Web.UI;
    using Business.Interfaces;
    using Business.Logic;

    public partial class Login : Page
    {
        private IAccountService ldapAccountService = new LdapAccountService();

        protected void Page_Load(object sender, EventArgs e)
        {
            txtbUsername.Focus();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            ILdapSettingsService ldapSettings = new LdapSettingsService();
            SetLdapSettings(ldapSettings);

            ILdapServerConnection ldapServerConnection = new LdapServerConnection();
            IAccountService accountService = new LdapAccountService();

            ILoginService loginService = new LoginService(ldapServerConnection, accountService);

            var response = loginService.Login(ldapSettings);

            if (response.User == null)
            {
                lblError.Visible = true;
                lblError.InnerText = response.ErrorMessage;
            }
            else
            {
                SignIn(response.User);
                Response.Redirect(Global.DashboardPage);
            }
        }

        protected void btnReset_ServerClick(object sender, EventArgs e)
        {
            lblError.Visible = false;
            txtbUsername.Value = string.Empty;
            txtbPassword.Value = string.Empty;
        }

        private void SetLdapSettings(ILdapSettingsService settings)
        {
            settings.ServerPath = WebConfigurationManager.AppSettings["LDAPServerPath"];
            settings.SearchRoot = WebConfigurationManager.AppSettings["LDAPSearchRoot"];
            settings.Username = txtbUsername.Value;
            settings.Password = txtbPassword.Value;
        }

        private void SignIn(IUser user)
        {
            var authenticationTicket = new FormsAuthenticationTicket(
                1,
                user.Username,
                DateTime.Now,
                DateTime.Now.AddMinutes(30),
                true,
                $"{user.Name}:{user.Team}:{user.Email}");

            var encryptedTicket = FormsAuthentication.Encrypt(authenticationTicket);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            cookie.Expires = authenticationTicket.Expiration;

            Response.Cookies.Add(cookie);
        }

        private void CreateAccountManager(ILdapServerConnection ldapConnection)
        {
            IAccountManager ldapManager = LdapAccountManager.Instance;
            ldapManager.Setup(ldapConnection);
        }
    }
}