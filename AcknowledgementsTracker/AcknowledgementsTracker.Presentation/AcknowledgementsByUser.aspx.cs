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

    public partial class AcknowledgementsByUser : System.Web.UI.Page
    {
        private string username;
        private UIHelper helper = new UIHelper();
        private IAcknowledgementDtoService acknowledgementDtoService = new AcknowledgementDtoService();

        protected void Page_Load(object sender, EventArgs e)
        {
            username = Request.QueryString["user"];
            ltrUser.Text = helper.GetUserFullName(username);

            gvAcknowledgementsReceived.DataSource = acknowledgementDtoService.ReadReceived(username);
            gvAcknowledgementsReceived.DataBind();

            gvAcknowledgementsGiven.DataSource = acknowledgementDtoService.ReadGiven(username);
            gvAcknowledgementsGiven.DataBind();
        }

        protected void gvAcknowledgementsReceived_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAcknowledgementsReceived.PageIndex = e.NewPageIndex;
            gvAcknowledgementsReceived.DataBind();
        }

        protected void gvAcknowledgementsGiven_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAcknowledgementsGiven.PageIndex = e.NewPageIndex;
            gvAcknowledgementsGiven.DataBind();
        }

        protected void btnCreateNew_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("~/NewAcknowledgement.aspx?beneficiary={0}", username));
        }
    }
}