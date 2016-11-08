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

            if (Request.QueryString["mode"] == "allTime")
            {
                gvAcknowledgementsByTag.DataSource = acknowledgementDtoService.ReadByTag(tag);
                gvAcknowledgementsByTag.DataBind();
            }
            else if (Request.QueryString["mode"] == "thisMonth")
            {
                ltrMonth.Text = $" for {DateTime.Today.ToString("MMMM yyyy", CultureInfo.InvariantCulture)}";

                gvAcknowledgementsByTag.DataSource = acknowledgementDtoService.ReadByTagThisMonth(tag);
                gvAcknowledgementsByTag.DataBind();
            }
        }

        protected void gvAcknowledgementsByTag_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAcknowledgementsByTag.PageIndex = e.NewPageIndex;
            gvAcknowledgementsByTag.DataBind();
        }
    }
}