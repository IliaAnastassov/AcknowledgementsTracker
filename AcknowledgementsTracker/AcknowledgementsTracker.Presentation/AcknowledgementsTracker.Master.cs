﻿namespace AcknowledgementsTracker.Presentation
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

    public partial class AcknowledgementsTracker1 : MasterPage
    {
        private LdapAccountService accountService = new LdapAccountService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (LdapAccountManager.HasInstance())
            {
                try
                {
                    var user = accountService.ReadUserData(HttpContext.Current.User.Identity.Name);
                    UserNameLabel.Text = $"{user.Name} email:{user.Email}";
                }
                catch
                {
                    LdapAccountManager.Instance.Destroy();
                    LogoutBtn.Visible = false;
                    FormsAuthentication.SignOut();
                }
            }
            else
            {
                LogoutBtn.Visible = false;
                FormsAuthentication.SignOut();
            }
        }

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            LogoutBtn.Visible = false;
            LdapAccountManager.Instance.Destroy();

            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}