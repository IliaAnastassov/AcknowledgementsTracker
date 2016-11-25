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
            if (!string.IsNullOrWhiteSpace(txtbUsername.Value)
                && !string.IsNullOrWhiteSpace(txtbPassword.Value))
            {
                ILdapSettingsService settings = new LdapSettingsService();
                SetLdapSettings(settings);

                ILdapServerConnection ldapConnection = new LdapServerConnection(settings);
                ldapConnection.Connect();

                if (ldapConnection.IsAuthenticated)
                {
                    CreateAccountManager(ldapConnection);
                    IUser user;

                    try
                    {
                        user = ldapAccountService.ReadUserData(txtbUsername.Value);
                    }
                    catch (ArgumentException)
                    {
                        var username = ldapAccountService.ReadUserUsername(txtbUsername.Value);
                        user = ldapAccountService.ReadUserData(username);
                    }

                    SignIn(user);
                    Response.Redirect(Global.DashboardPage);
                }
                else
                {
                    lblError.Visible = true;
                    lblError.InnerText = "Failed to authenticate. Please verify username and password";
                }
            }
            else
            {
                lblError.Visible = true;
                lblError.InnerText = "Please fill all textboxes";
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
            settings.UserPassword = txtbPassword.Value;
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