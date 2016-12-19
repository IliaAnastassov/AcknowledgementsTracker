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
        private UIHelper helper;
        private ILdapServerConnection connection;
        private IAcknowledgementDtoService acknowledgementDtoService = new AcknowledgementDtoService();

        protected void Page_Load(object sender, EventArgs e)
        {
            connection = (ILdapServerConnection)Session[Global.LdapConnection];
            helper = new UIHelper(connection);
            username = Request.QueryString["user"];
            ltrUser.Text = helper.GetUserFullName(username);
        }

        protected void btnCreateNew_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect($"{Global.NewAcknowledgementPage}?beneficiary={username}");
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
            if (mode == Global.ModeAllTime)
            {
                gvAcknowledgementsReceived.DataSource = acknowledgementDtoService.ReadReceived(username);
                gvAcknowledgementsReceived.DataBind();

                gvAcknowledgementsGiven.DataSource = acknowledgementDtoService.ReadGiven(username);
                gvAcknowledgementsGiven.DataBind();
            }
            else if (mode == Global.ModeAllTimeRec)
            {
                gvAcknowledgementsReceived.DataSource = acknowledgementDtoService.ReadReceived(username);
                gvAcknowledgementsReceived.DataBind();

                fldsAcknowledgementsGiven.Visible = false;
            }
            else if (mode == Global.ModeThisMonth)
            {
                ltrMonth.Text = $" for {DateTime.Today.ToString("MMMM yyyy", CultureInfo.InvariantCulture)}";

                gvAcknowledgementsReceived.DataSource = acknowledgementDtoService.ReadReceivedThisMonth(username);
                gvAcknowledgementsReceived.DataBind();

                fldsAcknowledgementsGiven.Visible = false;
            }
        }
    }
}