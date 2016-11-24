﻿namespace AcknowledgementsTracker.Presentation
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
            txtbUsername.Focus();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtbUsername.Value)
                && !string.IsNullOrWhiteSpace(txtbPassword.Value))
            {
                ILdapSettingsService settings = new LdapSettingsService();
                SetLdapSettings(settings);

                try
                {
                    ILdapServerConnection ldapConnection = new LdapServerConnection(settings);

                    if (ldapConnection.IsAuthenticated)
                    {
                        AddAuthentication(ldapConnection);
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

        private void AddAuthentication(ILdapServerConnection ldapConnection)
        {
            IAccountManager ldapManager = LdapAccountManager.Instance;
            ldapManager.Setup(ldapConnection);

            var authenticationTicket = new FormsAuthenticationTicket(1, txtbUsername.Value, DateTime.Now, DateTime.Now.AddMinutes(30), true, string.Empty);
            var encryptedTicket = FormsAuthentication.Encrypt(authenticationTicket);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            cookie.Expires = authenticationTicket.Expiration;
            Response.Cookies.Add(cookie);
        }
    }
}