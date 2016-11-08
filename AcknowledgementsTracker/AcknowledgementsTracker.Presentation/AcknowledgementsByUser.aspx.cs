namespace AcknowledgementsTracker.Presentation
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Business.Interfaces;
    using Business.Logic;

    public partial class AcknowledgementsByUser : Page
    {
        private string username;
        private UIHelper helper = new UIHelper();
        private IAcknowledgementDtoService acknowledgementDtoService = new AcknowledgementDtoService();

        protected void Page_Load(object sender, EventArgs e)
        {
            username = Request.QueryString["user"];
            ltrUser.Text = helper.GetUserFullName(username);

            if (Request.QueryString["mode"] == "allTime")
            {
                gvAcknowledgementsReceived.DataSource = acknowledgementDtoService.ReadReceived(username);
                gvAcknowledgementsReceived.DataBind();

                gvAcknowledgementsGiven.DataSource = acknowledgementDtoService.ReadGiven(username);
                gvAcknowledgementsGiven.DataBind();
            }
            else if (Request.QueryString["mode"] == "allTime_Rec")
            {
                gvAcknowledgementsReceived.DataSource = acknowledgementDtoService.ReadReceived(username);
                gvAcknowledgementsReceived.DataBind();

                fldsAcknowledgementsGiven.Visible = false;
            }
            else if (Request.QueryString["mode"] == "thisMonth")
            {
                ltrMonth.Text = $" for {DateTime.Today.ToString("MMMM yyyy", CultureInfo.InvariantCulture)}";

                gvAcknowledgementsReceived.DataSource = acknowledgementDtoService.ReadReceivedThisMonth(username);
                gvAcknowledgementsReceived.DataBind();

                fldsAcknowledgementsGiven.Visible = false;
            }
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