namespace AcknowledgementsTracker.Presentation
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Business.Logic;
    using System.Web.Security;
    using Business.Interfaces;

    public partial class LoggedIn : MasterPage
    {
        ILdapServerConnection connection;

        protected void Page_Load(object sender, EventArgs e)
        {
            var username = HttpContext.Current.User.Identity.Name;
            connection = (ILdapServerConnection)Session[Global.LdapConnection];

            if (connection == null)
            {
                SignOut();
            }
            else
            {
                IAccountService accountService = new LdapAccountService();
                accountService.SetAccountManager(connection);
            }
        }

        public string GetFullName(string username)
        {
            string fullName = string.Empty;

            if (connection != null)
            {
                IAccountService accountService = new LdapAccountService();
                accountService.SetAccountManager(connection);

                fullName = accountService.ReadUserFullName(username);
            }

            return fullName;
        }

        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            SignOut();
        }

        private void SignOut()
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}