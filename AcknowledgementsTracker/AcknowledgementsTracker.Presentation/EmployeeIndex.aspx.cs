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
        private ILdapAccountService ldapService = new LdapAccountService();

        protected void Page_Load(object sender, EventArgs e)
        {
            gvEmployees.DataSource = ldapService.ReadAllUsersData();
            gvEmployees.DataBind();
        }

        protected void gvEmployees_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployees.PageIndex = e.NewPageIndex;
            gvEmployees.DataBind();
        }
    }
}