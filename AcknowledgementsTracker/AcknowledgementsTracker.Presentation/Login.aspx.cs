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
                var connection = new LdapConnection(settings);

                if (connection.IsAuthenticated())
                {
                    var manager = LdapAccountManager.Instance;
                    manager.Setup(WebConfigurationManager.AppSettings["Domain"], settings.Username, settings.UserPassword);

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

        private void SaveUserConfiguration(string username, string password)
        {
            var config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
            config.AppSettings.Settings.Remove("Username");
            config.AppSettings.Settings.Remove("Password");
            config.AppSettings.Settings.Add("Username", username);
            config.AppSettings.Settings.Add("Password", password);
            config.Save();
        }
    }
}