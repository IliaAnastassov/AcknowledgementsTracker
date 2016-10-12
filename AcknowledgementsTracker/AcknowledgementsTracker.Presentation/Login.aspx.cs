namespace AcknowledgementsTracker.Presentation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Web;
    using System.Web.Configuration;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Business.Interfaces;
    using Business.Logic;
    using System.Web.UI.HtmlControls;

    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            ILdapSettingsService settings = new LdapSettingsService();

            settings.Path = WebConfigurationManager.AppSettings["LDAPServerPath"];
            settings.Username = UsernameTextBox.Value;
            settings.UserPassword = PasswordTextBox.Value;

            try
            {
                var connection = new CustomLdapConnection(settings);

                if (connection.IsAuthenticated())
                {
                    // TODO:

                    var authenticationTicket = new FormsAuthenticationTicket(1, UsernameTextBox.Value, DateTime.Now, DateTime.Now.AddMinutes(60), true, string.Empty);
                    var encryptedTicket = FormsAuthentication.Encrypt(authenticationTicket);

                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    cookie.Expires = authenticationTicket.Expiration;
                    Response.Cookies.Add(cookie);

                    Response.Redirect(@"~/Dashboard.aspx");
                }
            }
            catch (ThreadAbortException)
            {
            }
            catch (HttpException)
            {
            }
            catch (Exception)
            {
                ErrorLabel.InnerText = "Failed to authenticate. Please verify username and password.";
            }
        }
    }
}