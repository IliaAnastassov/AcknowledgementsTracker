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

    public partial class EmployeeIndex : System.Web.UI.Page
    {
        private IAccountService ldapService = new LdapAccountService();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void gvEmployees_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployees.DataSource = ldapService.ReadAllUsersData();
            gvEmployees.PageIndex = e.NewPageIndex;
            gvEmployees.DataBind();

            tmrEmployees.Enabled = false;
            pnlEmployees.Visible = false;
        }

        protected void tmrEmployees_Tick(object sender, EventArgs e)
        {
            gvEmployees.DataSource = ldapService.ReadAllUsersData();
            gvEmployees.DataBind();

            tmrEmployees.Enabled = false;
            pnlEmployees.Visible = false;
        }
    }
}