namespace AcknowledgementsTracker.Presentation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using DTO;
    using Business.Interfaces;
    using Business.Logic;

    public partial class AcknowledgementsByTag : System.Web.UI.Page
    {
        private ISearchService searcher = new SearchService();

        protected void Page_Load(object sender, EventArgs e)
        {
            ltrTag.Text = Request.QueryString["tag"];
            gvAcknowledgementsByTag.DataSource = searcher.FindAcknowledgementsByTag(ltrTag.Text);
            gvAcknowledgementsByTag.DataBind();
        }

        protected void gvAcknowledgementsByTag_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAcknowledgementsByTag.PageIndex = e.NewPageIndex;
            gvAcknowledgementsByTag.DataBind();
        }
    }
}