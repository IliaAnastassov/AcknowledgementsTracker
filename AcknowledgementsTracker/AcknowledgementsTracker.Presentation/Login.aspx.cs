namespace AcknowledgementsTracker.Presentation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.Configuration;
    using Business.Logic;
    using Business.Interfaces;
    using System.Web.Security;

    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            ILdapSettingsService settings = new LdapSettingsService();

            settings.Path = WebConfigurationManager.AppSettings["LDAPServerPath"];
            settings.Username = WebConfigurationManager.AppSettings["LDAPUsername"];
            settings.UserPassword = WebConfigurationManager.AppSettings["LDAPUserPassword"];

            var authentication = new LdapAuthentication(new LdapConnection(settings));

            try
            {
                var authenticated = authentication.IsAuthenticated(UsernameTextBox.Value, PasswordTextBox.Value);

                if (authenticated)
                {
                    var authenticationTicket = new FormsAuthenticationTicket(1, UsernameTextBox.Value, DateTime.Now, DateTime.Now.AddMinutes(60), true, string.Empty);
                    var encryptedTicket = FormsAuthentication.Encrypt(authenticationTicket);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    cookie.Expires = authenticationTicket.Expiration;
                    Response.Cookies.Add(cookie);
                    Response.Redirect(@"~/Dashboard.aspx");
                }
            }
            catch (ArgumentNullException ex)
            {
                // TODO: Create a MessageBox informing that the user is not found
            }
            catch (HttpException)
            {
                // TODO:
            }
            catch (Exception)
            {
                // TODO:
            }
        }
    }
}