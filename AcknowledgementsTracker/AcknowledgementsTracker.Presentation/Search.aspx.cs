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

    public partial class Search : Page
    {
        private IAccountService ldapAccountService = new LdapAccountService();
        private ISearchService searcher = new SearchService();

        public string SearchQuery
        {
            get
            {
                if (ViewState["SearchQuery"] == null)
                {
                    return string.Empty;
                }

                return (string)ViewState["SearchQuery"];
            }

            set
            {
                ViewState["SearchQuery"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!fldsAcknowledgementsResults.Visible && !fldsEmployeesResults.Visible)
            {
                txtbSearch.Focus();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchQuery = txtbSearch.Value.Trim();

            if (!string.IsNullOrWhiteSpace(SearchQuery))
            {
                ErrorLabel.Visible = false;
                BindGvEmployeesResults(SearchQuery);
                BindGvAcknowledgementsResults(SearchQuery);
            }
            else
            {
                ErrorLabel.Visible = true;
                ErrorLabel.InnerText = "Please fill the search textbox";
            }
        }

        protected void btnReset_ServerClick(object sender, EventArgs e)
        {
            txtbSearch.Value = string.Empty;
            SearchQuery = string.Empty;

            fldsEmployeesResults.Visible = false;
            fldsAcknowledgementsResults.Visible = false;
            ErrorLabel.Visible = false;

            txtbSearch.Focus();
        }

        protected void gvEmployeesResults_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            tmrEmployeesResults.Enabled = false;

            gvEmployeesResults.DataSource = searcher.FindUsers(SearchQuery);
            gvEmployeesResults.PageIndex = e.NewPageIndex;
            gvEmployeesResults.DataBind();

            fldsEmployeesResults.Visible = true;
            pnlEmployeesResults.Visible = false;
        }

        protected void gvAcknowledgementsResults_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            tmrAcknowledgementsResults.Enabled = false;

            gvAcknowledgementsResults.DataSource = searcher.FindByKeywords(SearchQuery);
            gvAcknowledgementsResults.PageIndex = e.NewPageIndex;
            gvAcknowledgementsResults.DataBind();

            fldsAcknowledgementsResults.Visible = true;
            pnlAcknowledgementsResults.Visible = false;
        }

        protected void tmrEmployeesResults_Tick(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SearchQuery) && fldsEmployeesResults.Visible)
            {
                tmrEmployeesResults.Enabled = false;
                BindGvEmployeesResults(SearchQuery);
            }
        }

        protected void tmrAcknowledgementsResults_Tick(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SearchQuery) && fldsAcknowledgementsResults.Visible)
            {
                tmrAcknowledgementsResults.Enabled = false;
                BindGvAcknowledgementsResults(SearchQuery);
            }
        }

        private void BindGvEmployeesResults(string searchQuery)
        {
            gvEmployeesResults.DataSource = searcher.FindUsers(searchQuery);
            gvEmployeesResults.DataBind();

            fldsEmployeesResults.Visible = true;
            pnlEmployeesResults.Visible = false;
        }

        private void BindGvAcknowledgementsResults(string searchQuery)
        {
            gvAcknowledgementsResults.DataSource = searcher.FindByKeywords(searchQuery);
            gvAcknowledgementsResults.DataBind();

            fldsAcknowledgementsResults.Visible = true;
            pnlAcknowledgementsResults.Visible = false;
        }
    }
}