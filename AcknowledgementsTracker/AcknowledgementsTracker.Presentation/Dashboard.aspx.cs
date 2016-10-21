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

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnInitComplete(EventArgs e)
        {
            username = HttpContext.Current.User.Identity.Name;
            base.OnInitComplete(e);
            BindGridViews();
        }

        protected void BindGridViews()
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

            // Bind All Time Champion
            ltrAllTimeChampion.Text = acknowledgementDtoService.ReadAllTimeChampion();

            // Bind All Time Top Ten
            AllTimeTopTenGridView.DataSource = acknowledgementDtoService.ReadAllTimeTopTen();
            AllTimeTopTenGridView.DataBind();
        }

        protected void AcknowledgementsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var ltrTags = e.Row.FindControl("ltrTags") as Literal;
                var acknowledgement = e.Row.DataItem as AcknowledgementDTO;
                var tagTitles = new List<string>();

                foreach (var tag in acknowledgement.Tags)
                {
                    tagTitles.Add(tag.Title);
                }

                ltrTags.Text = string.Join(" ", tagTitles);
            }
        }
    }
}