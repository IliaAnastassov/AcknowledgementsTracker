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
        }

        protected void btnCreateNew_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("~/NewAcknowledgement.aspx?beneficiary={0}", username));
        }

        protected void tmrAcknowledgementsReceived_Tick(object sender, EventArgs e)
        {
            var mode = Request.QueryString["mode"];
            BindGrid(mode);

            tmrAcknowledgementsReceived.Enabled = false;
            pnlAcknowledgementsReceived.Visible = false;
        }

        protected void tmrAcknowledgementsGiven_Tick(object sender, EventArgs e)
        {
            var mode = Request.QueryString["mode"];
            BindGrid(mode);

            tmrAcknowledgementsGiven.Enabled = false;
            pnlAcknowledgementsGiven.Visible = false;
        }

        protected void gvAcknowledgementsReceived_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            var mode = Request.QueryString["mode"];
            BindGrid(mode);

            gvAcknowledgementsReceived.PageIndex = e.NewPageIndex;
            gvAcknowledgementsReceived.DataBind();

            tmrAcknowledgementsReceived.Enabled = false;
            pnlAcknowledgementsReceived.Visible = false;
        }

        protected void gvAcknowledgementsGiven_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            var mode = Request.QueryString["mode"];
            BindGrid(mode);

            gvAcknowledgementsGiven.PageIndex = e.NewPageIndex;
            gvAcknowledgementsGiven.DataBind();

            tmrAcknowledgementsGiven.Enabled = false;
            pnlAcknowledgementsGiven.Visible = false;
        }

        private void BindGrid(string mode)
        {
            if (mode == "allTime")
            {
                gvAcknowledgementsReceived.DataSource = acknowledgementDtoService.ReadReceived(username);
                gvAcknowledgementsReceived.DataBind();

                gvAcknowledgementsGiven.DataSource = acknowledgementDtoService.ReadGiven(username);
                gvAcknowledgementsGiven.DataBind();
            }
            else if (mode == "allTime_Rec")
            {
                gvAcknowledgementsReceived.DataSource = acknowledgementDtoService.ReadReceived(username);
                gvAcknowledgementsReceived.DataBind();

                fldsAcknowledgementsGiven.Visible = false;
            }
            else if (mode == "thisMonth")
            {
                ltrMonth.Text = $" for {DateTime.Today.ToString("MMMM yyyy", CultureInfo.InvariantCulture)}";

                gvAcknowledgementsReceived.DataSource = acknowledgementDtoService.ReadReceivedThisMonth(username);
                gvAcknowledgementsReceived.DataBind();

                fldsAcknowledgementsGiven.Visible = false;
            }
        }
    }
}