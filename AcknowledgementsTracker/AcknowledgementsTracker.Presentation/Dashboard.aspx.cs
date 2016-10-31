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
        private ILdapAccountService ldapAccountService = new LdapAccountService();
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
            UserAcknowledgementsGridView.DataSource = acknowledgementDtoService.Read(username);
            UserAcknowledgementsGridView.DataBind();

            // Bind last acknowledgements
            LastAcknowledgemetsGridView.DataSource = acknowledgementDtoService.ReadLast();
            LastAcknowledgemetsGridView.DataBind();

            // Bind today's acknowledgements
            TodaysAcknowledgementsGridView.DataSource = acknowledgementDtoService.ReadTodays();
            TodaysAcknowledgementsGridView.DataBind();

            // Bind this week's acknowledgements
            ThisWeeksAcknowledgementsGridView.DataSource = acknowledgementDtoService.ReadThisWeek();
            ThisWeeksAcknowledgementsGridView.DataBind();

            // Bind this month's acknowledgements
            ThisMonthsAcknowledgementsGridView.DataSource = acknowledgementDtoService.ReadThisMonth();
            ThisMonthsAcknowledgementsGridView.DataBind();

            // Bind All Time Top Ten
            AllTimeTopTenGridView.DataSource = acknowledgementDtoService.ReadAllTimeTopTen();
            AllTimeTopTenGridView.DataBind();

            // Bind This Month Top Ten
            ThisMonthTopTenGridView.DataSource = acknowledgementDtoService.ReadThisMonthTopTen();
            ThisMonthTopTenGridView.DataBind();

            // Bind Top Tags All time
            MostFrequentTagsAllTimeGV.DataSource = tagDtoService.ReadMostFrequentTagsAllTime();
            MostFrequentTagsAllTimeGV.DataBind();

            // Bind Top Tags This Month
            MostFrequentTagsThisMonthGV.DataSource = tagDtoService.ReadMostFrequentTagsThisMonth();
            MostFrequentTagsThisMonthGV.DataBind();
        }

        protected void ThisMonthsAcknowledgementsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ThisMonthsAcknowledgementsGridView.PageIndex = e.NewPageIndex;
            ThisMonthsAcknowledgementsGridView.DataBind();
        }

        protected void UserAcknowledgementsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            UserAcknowledgementsGridView.PageIndex = e.NewPageIndex;
            UserAcknowledgementsGridView.DataBind();
        }

        protected void TodaysAcknowledgementsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            TodaysAcknowledgementsGridView.PageIndex = e.NewPageIndex;
            TodaysAcknowledgementsGridView.DataBind();
        }

        protected void ThisWeeksAcknowledgementsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ThisWeeksAcknowledgementsGridView.PageIndex = e.NewPageIndex;
            ThisWeeksAcknowledgementsGridView.DataBind();
        }

        protected string GetUserFullName(string username)
        {
            return ldapAccountService.ReadUserFullName(username);
        }

        protected IEnumerable<string> GetTags(IEnumerable<TagDTO> tags)
        {
            var tagTitles = new List<string>();

            foreach (var tag in tags)
            {
                tagTitles.Add(tag.Title);
            }

            return tagTitles;
        }
    }
}