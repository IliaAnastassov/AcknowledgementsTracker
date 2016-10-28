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
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(UsernameTextBox.Value)
                && !string.IsNullOrWhiteSpace(PasswordTextBox.Value))
            {
                ILdapSettingsService settings = new LdapSettingsService();
                settings.ServerPath = WebConfigurationManager.AppSettings["LDAPServerPath"];
                settings.SearchRoot = WebConfigurationManager.AppSettings["LDAPSearchRoot"];
                settings.Username = UsernameTextBox.Value;
                settings.UserPassword = PasswordTextBox.Value;

                try
                {
                    ILdapServerConnection ldapConnection = new LdapServerConnection(settings);

                    if (ldapConnection.IsAuthenticated())
                    {
                        ILdapAccountManager ldapManager = LdapAccountManager.Instance;
                        ldapManager.Setup(ldapConnection);

                        var authenticationTicket = new FormsAuthenticationTicket(1, UsernameTextBox.Value, DateTime.Now, DateTime.Now.AddMinutes(30), true, string.Empty);
                        var encryptedTicket = FormsAuthentication.Encrypt(authenticationTicket);

                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                        cookie.Expires = authenticationTicket.Expiration;
                        Response.Cookies.Add(cookie);

                        Response.Redirect(Global.DashboardPage);
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (ThreadAbortException)
                {
                }
                catch (Exception)
                {
                    ErrorLabel.InnerText = "Failed to authenticate. Please verify username and password";
                }
            }
            else
            {
                ErrorLabel.InnerText = "Please fill all boxes";
            }
        }

        protected void ResetBtn_ServerClick(object sender, EventArgs e)
        {
            UsernameTextBox.Value = string.Empty;
            PasswordTextBox.Value = string.Empty;
        }
    }
}