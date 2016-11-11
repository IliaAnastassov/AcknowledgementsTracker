namespace AcknowledgementsTracker.Presentation
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Business.Interfaces;
    using Business.Logic;
    using DTO;
    using System.Data;

    public partial class Dashboard : Page
    {
        private string username;
        private IAcknowledgementDtoService acknowledgementDtoService = new AcknowledgementDtoService();
        private ITagDtoService tagDtoService = new TagDtoService();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void gvUserAcknowledgements_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            username = HttpContext.Current.User.Identity.Name;
            gvUserAcknowledgements.DataSource = acknowledgementDtoService.ReadReceived(username);
            gvUserAcknowledgements.PageIndex = e.NewPageIndex;
            gvUserAcknowledgements.DataBind();
        }

        protected void gvTodaysAcknowledgements_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTodaysAcknowledgements.DataSource = acknowledgementDtoService.ReadTodays();
            gvTodaysAcknowledgements.PageIndex = e.NewPageIndex;
            gvTodaysAcknowledgements.DataBind();
        }

        protected void gvThisWeeksAcknowledgements_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvThisWeeksAcknowledgements.DataSource = acknowledgementDtoService.ReadThisWeek();
            gvThisWeeksAcknowledgements.PageIndex = e.NewPageIndex;
            gvThisWeeksAcknowledgements.DataBind();
        }

        protected void ThisMonthsAcknowledgementsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvThisMonthsAcknowledgements.DataSource = acknowledgementDtoService.ReadThisMonth();
            gvThisMonthsAcknowledgements.PageIndex = e.NewPageIndex;
            gvThisMonthsAcknowledgements.DataBind();
        }

        protected void tmrUserAcknowledgements_Tick(object sender, EventArgs e)
        {
            username = HttpContext.Current.User.Identity.Name;
            gvUserAcknowledgements.DataSource = acknowledgementDtoService.ReadReceived(username);
            gvUserAcknowledgements.DataBind();

            tmrUserAcknowledgements.Enabled = false;
            pnlUserAcknowledgementsLoader.Visible = false;
        }

        protected void tmrLastAcknowledgements_Tick(object sender, EventArgs e)
        {
            gvLastAcknowledgemets.DataSource = acknowledgementDtoService.ReadLast();
            gvLastAcknowledgemets.DataBind();

            tmrLastAcknowledgements.Enabled = false;
            pnlLastAcknowledgements.Visible = false;
        }

        protected void tmrTodaysAcknowledgements_Tick(object sender, EventArgs e)
        {
            gvTodaysAcknowledgements.DataSource = acknowledgementDtoService.ReadTodays();
            gvTodaysAcknowledgements.DataBind();

            tmrTodaysAcknowledgements.Enabled = false;
            pnlTodaysAcknowledgements.Visible = false;
        }

        protected void tmrThisWeeksAcnowledgements_Tick(object sender, EventArgs e)
        {
            gvThisWeeksAcknowledgements.DataSource = acknowledgementDtoService.ReadThisWeek();
            gvThisWeeksAcknowledgements.DataBind();

            tmrThisWeeksAcnowledgements.Enabled = false;
            pnlThisWeeksAcnowledgements.Visible = false;
        }

        protected void tmrThisMonthAcknowledgements_Tick(object sender, EventArgs e)
        {
            gvThisMonthsAcknowledgements.DataSource = acknowledgementDtoService.ReadThisMonth();
            gvThisMonthsAcknowledgements.DataBind();

            tmrThisMonthAcknowledgements.Enabled = false;
            pnlThisMonthAcknowledgements.Visible = false;
        }

        protected void tmrAllTimeTopTen_Tick(object sender, EventArgs e)
        {
            gvAllTimeTopTen.DataSource = acknowledgementDtoService.ReadAllTimeTopTen();
            gvAllTimeTopTen.DataBind();

            tmrAllTimeTopTen.Enabled = false;
            pnlAllTimeTopTen.Visible = false;
        }

        protected void tmrThisMonthTopTen_Tick(object sender, EventArgs e)
        {
            gvThisMonthTopTen.DataSource = acknowledgementDtoService.ReadThisMonthTopTen();
            gvThisMonthTopTen.DataBind();

            tmrThisMonthTopTen.Enabled = false;
            pnlThisMonthTopTen.Visible = false;
        }

        protected void tmrMostFrequentTagsAllTime_Tick(object sender, EventArgs e)
        {
            gvMostFrequentTagsAllTime.DataSource = tagDtoService.ReadMostFrequentTagsAllTime();
            gvMostFrequentTagsAllTime.DataBind();

            tmrMostFrequentTagsAllTime.Enabled = false;
            pnlMostFrequentTagsAllTime.Visible = false;
        }

        protected void tmrMostFrequentTagsThisMonth_Tick(object sender, EventArgs e)
        {
            gvMostFrequentTagsThisMonth.DataSource = tagDtoService.ReadMostFrequentTagsThisMonth();
            gvMostFrequentTagsThisMonth.DataBind();

            tmrMostFrequentTagsThisMonth.Enabled = false;
            pnlMostFrequentTagsThisMonth.Visible = false;
        }
    }
}