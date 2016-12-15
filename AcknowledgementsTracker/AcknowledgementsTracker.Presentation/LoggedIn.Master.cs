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

        protected void Page_Load(object sender, EventArgs e)
        {
            var username = HttpContext.Current.User.Identity.Name;
            var ldapConnection = (LdapServerConnection)Session["connection"];

            IAccountService accountService = new LdapAccountService();
            accountService.SetAccountManager(ldapConnection);

            try
            {
                parUserName.InnerText = accountService.ReadUserFullName(username);
            }
            catch (NullReferenceException)
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            LdapAccountManager.Instance.Destroy();
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}