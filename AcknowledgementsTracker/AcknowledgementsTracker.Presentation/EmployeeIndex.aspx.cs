namespace AcknowledgementsTracker.Presentation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Business.Interfaces;
    using Business.Logic;

    public partial class EmployeeIndex : Page
    {
        private IAccountService ldapAccountService;

        protected void Page_Load(object sender, EventArgs e)
        {
            var connection = (ILdapServerConnection)Session[Global.LdapConnection];
            ldapAccountService = new LdapAccountService();
            ldapAccountService.SetAccountManager(connection);
        }

        protected void gvEmployees_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployees.DataSource = ldapAccountService.ReadAllUsersData();
            gvEmployees.PageIndex = e.NewPageIndex;
            gvEmployees.DataBind();

            tmrEmployees.Enabled = false;
            pnlEmployees.Visible = false;
        }

        protected void tmrEmployees_Tick(object sender, EventArgs e)
        {
            gvEmployees.DataSource = ldapAccountService.ReadAllUsersData();
            gvEmployees.DataBind();

            tmrEmployees.Enabled = false;
            pnlEmployees.Visible = false;
        }
    }
}