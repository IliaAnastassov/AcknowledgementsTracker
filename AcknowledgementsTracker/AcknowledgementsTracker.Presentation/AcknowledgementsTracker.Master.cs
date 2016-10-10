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

    public partial class AcknowledgementsTracker1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (LdapAccountManager.Instance != null)
            {
                LogoutBtn.Visible = true;
            }
        }

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            LdapAccountManager.Instance.Destroy();
        }
    }
}