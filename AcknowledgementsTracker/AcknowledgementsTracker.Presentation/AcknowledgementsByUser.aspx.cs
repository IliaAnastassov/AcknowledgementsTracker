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
        private UIHelper helper = new UIHelper();
        private IAcknowledgementDtoService acknowledgementDtoService = new AcknowledgementDtoService();

        protected void Page_Load(object sender, EventArgs e)
        {
            ltrUser.Text = helper.GetUserFullName(Request.QueryString["user"]);
            gvAcknowledgementsReceived.DataSource = acknowledgementDtoService.Read(Request.QueryString["user"]);
            gvAcknowledgementsReceived.DataBind();
        }

        protected void gvAcknowledgementsReceived_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAcknowledgementsReceived.PageIndex = e.NewPageIndex;
            gvAcknowledgementsReceived.DataBind();
        }
    }
}