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
    using DTO;

    public partial class AcknowledgementsByTag : Page
    {
        private ISearchService searcher = new SearchService();
        private IAcknowledgementDtoService acknowledgementDtoService = new AcknowledgementDtoService();
        private string tag;

        protected void Page_Load(object sender, EventArgs e)
        {
            tag = Request.QueryString["tag"];
            ltrTag.Text = $" {tag}";
        }

        protected void gvAcknowledgementsByTag_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            var mode = Request.QueryString["mode"];
            BindGrid(mode);

            gvAcknowledgementsByTag.PageIndex = e.NewPageIndex;
            gvAcknowledgementsByTag.DataBind();

            tmrAcknowledgementsByTag.Enabled = false;
            pnlAcknowledgementsByTag.Visible = false;
        }

        protected void tmrAcknowledgementsByTag_Tick(object sender, EventArgs e)
        {
            var mode = Request.QueryString["mode"];
            BindGrid(mode);

            tmrAcknowledgementsByTag.Enabled = false;
            pnlAcknowledgementsByTag.Visible = false;
        }

        private void BindGrid(string mode)
        {
            if (mode == "allTime")
            {
                gvAcknowledgementsByTag.DataSource = acknowledgementDtoService.ReadByTag(tag);
                gvAcknowledgementsByTag.DataBind();
            }
            else if (mode == "thisMonth")
            {
                ltrMonth.Text = $" for {DateTime.Today.ToString("MMMM yyyy", CultureInfo.InvariantCulture)}";

                gvAcknowledgementsByTag.DataSource = acknowledgementDtoService.ReadByTagThisMonth(tag);
                gvAcknowledgementsByTag.DataBind();
            }
        }
    }
}