namespace AcknowledgementsTracker.Presentation
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Business.Interfaces;
    using Business.Logic;
    using DTO;

    public partial class Dashboard : Page
    {
        private string username;
        private IAcknowledgementDtoService acknowledgementDtoService = new AcknowledgementDtoService();
        private ITagDtoService tagDtoService = new TagDtoService();

        protected void Page_Load(object sender, EventArgs e)
        {
            username = HttpContext.Current.User.Identity.Name;
            BindGridViews();
        }

        private void BindGridViews()
        {
            // Bind user acknowledgements
            gvUserAcknowledgements.DataSource = acknowledgementDtoService.ReadReceived(username);
            gvUserAcknowledgements.DataBind();

            // Bind last acknowledgements
            gvLastAcknowledgemets.DataSource = acknowledgementDtoService.ReadLast();
            gvLastAcknowledgemets.DataBind();

            // Bind today's acknowledgements
            gvTodaysAcknowledgements.DataSource = acknowledgementDtoService.ReadTodays();
            gvTodaysAcknowledgements.DataBind();

            // Bind this week's acknowledgements
            gvThisWeeksAcknowledgements.DataSource = acknowledgementDtoService.ReadThisWeek();
            gvThisWeeksAcknowledgements.DataBind();

            // Bind this month's acknowledgements
            gvThisMonthsAcknowledgements.DataSource = acknowledgementDtoService.ReadThisMonth();
            gvThisMonthsAcknowledgements.DataBind();

            // Bind All Time Top Ten Users
            gvAllTimeTopTen.DataSource = acknowledgementDtoService.ReadAllTimeTopTen();
            gvAllTimeTopTen.DataBind();

            // Bind This Month Top Ten Users
            gvThisMonthTopTen.DataSource = acknowledgementDtoService.ReadThisMonthTopTen();
            gvThisMonthTopTen.DataBind();

            // Bind Top Tags All time
            gvMostFrequentTagsAllTime.DataSource = tagDtoService.ReadMostFrequentTagsAllTime();
            gvMostFrequentTagsAllTime.DataBind();

            // Bind Top Tags This Month
            gvMostFrequentTagsThisMonth.DataSource = tagDtoService.ReadMostFrequentTagsThisMonth();
            gvMostFrequentTagsThisMonth.DataBind();
        }

        protected void ThisMonthsAcknowledgementsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvThisMonthsAcknowledgements.PageIndex = e.NewPageIndex;
            gvThisMonthsAcknowledgements.DataBind();
        }

        protected void UserAcknowledgementsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUserAcknowledgements.PageIndex = e.NewPageIndex;
            gvUserAcknowledgements.DataBind();
        }

        protected void TodaysAcknowledgementsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTodaysAcknowledgements.PageIndex = e.NewPageIndex;
            gvTodaysAcknowledgements.DataBind();
        }

        protected void ThisWeeksAcknowledgementsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvThisWeeksAcknowledgements.PageIndex = e.NewPageIndex;
            gvThisWeeksAcknowledgements.DataBind();
        }
    }
}