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
        private ILdapServerConnection ldapConnection;
        private IAccountService accountService;
        private IAcknowledgementDtoService acknowledgementDtoService;
        private ITagDtoService tagDtoService;

        protected void Page_Load(object sender, EventArgs e)
        {
            ldapConnection = (ILdapServerConnection)Session["connection"];
            accountService = new LdapAccountService();
            accountService.SetAccountManager(ldapConnection);

            acknowledgementDtoService = new AcknowledgementDtoService();
            tagDtoService = new TagDtoService();
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
            tmrUserAcknowledgements.Enabled = false;
            pnlUserAcknowledgementsLoader.Visible = false;

            username = HttpContext.Current.User.Identity.Name;

            gvUserAcknowledgements.DataSource = acknowledgementDtoService.ReadReceived(username);
            gvUserAcknowledgements.DataBind();
        }

        protected void tmrLastAcknowledgements_Tick(object sender, EventArgs e)
        {
            tmrLastAcknowledgements.Enabled = false;
            pnlLastAcknowledgements.Visible = false;

            gvLastAcknowledgemets.DataSource = acknowledgementDtoService.ReadLast();
            gvLastAcknowledgemets.DataBind();
        }

        protected void tmrTodaysAcknowledgements_Tick(object sender, EventArgs e)
        {
            tmrTodaysAcknowledgements.Enabled = false;
            pnlTodaysAcknowledgements.Visible = false;

            gvTodaysAcknowledgements.DataSource = acknowledgementDtoService.ReadTodays();
            gvTodaysAcknowledgements.DataBind();
        }

        protected void tmrThisWeeksAcnowledgements_Tick(object sender, EventArgs e)
        {
            tmrThisWeeksAcnowledgements.Enabled = false;
            pnlThisWeeksAcnowledgements.Visible = false;

            gvThisWeeksAcknowledgements.DataSource = acknowledgementDtoService.ReadThisWeek();
            gvThisWeeksAcknowledgements.DataBind();
        }

        protected void tmrThisMonthAcknowledgements_Tick(object sender, EventArgs e)
        {
            tmrThisMonthAcknowledgements.Enabled = false;
            pnlThisMonthAcknowledgements.Visible = false;

            gvThisMonthsAcknowledgements.DataSource = acknowledgementDtoService.ReadThisMonth();
            gvThisMonthsAcknowledgements.DataBind();
        }

        protected void tmrAllTimeTopTen_Tick(object sender, EventArgs e)
        {
            tmrAllTimeTopTen.Enabled = false;
            pnlAllTimeTopTen.Visible = false;

            gvAllTimeTopTen.DataSource = acknowledgementDtoService.ReadAllTimeTopTen();
            gvAllTimeTopTen.DataBind();
        }

        protected void tmrThisMonthTopTen_Tick(object sender, EventArgs e)
        {
            tmrThisMonthTopTen.Enabled = false;
            pnlThisMonthTopTen.Visible = false;

            gvThisMonthTopTen.DataSource = acknowledgementDtoService.ReadThisMonthTopTen();
            gvThisMonthTopTen.DataBind();
        }

        protected void tmrMostFrequentTagsAllTime_Tick(object sender, EventArgs e)
        {
            tmrMostFrequentTagsAllTime.Enabled = false;
            pnlMostFrequentTagsAllTime.Visible = false;

            gvMostFrequentTagsAllTime.DataSource = tagDtoService.ReadMostFrequentTagsAllTime();
            gvMostFrequentTagsAllTime.DataBind();
        }

        protected void tmrMostFrequentTagsThisMonth_Tick(object sender, EventArgs e)
        {
            tmrMostFrequentTagsThisMonth.Enabled = false;
            pnlMostFrequentTagsThisMonth.Visible = false;

            gvMostFrequentTagsThisMonth.DataSource = tagDtoService.ReadMostFrequentTagsThisMonth();
            gvMostFrequentTagsThisMonth.DataBind();
        }
    }
}