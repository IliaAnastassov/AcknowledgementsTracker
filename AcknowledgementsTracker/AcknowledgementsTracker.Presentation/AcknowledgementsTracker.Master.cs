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

    public partial class AcknowledgementsTracker1 : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (LdapAccountManager.HasInstance())
            {
                var user = LdapAccountManager.Instance.GetUserData();
                UserNameLabel.Text = $"{user.Name} email:{user.Email}";
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