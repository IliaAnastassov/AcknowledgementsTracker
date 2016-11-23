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

    public partial class Search : System.Web.UI.Page
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
                BindGridViews(SearchQuery);
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
            gvEmployeesResults.DataSource = searcher.FindUsers(SearchQuery);
            gvEmployeesResults.PageIndex = e.NewPageIndex;
            gvEmployeesResults.DataBind();

            tmrEmployeesResults.Enabled = false;
            pnlEmployeesResults.Visible = false;
        }

        protected void gvAcknowledgementsResults_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAcknowledgementsResults.DataSource = searcher.FindAcknowledgements(SearchQuery);
            gvAcknowledgementsResults.PageIndex = e.NewPageIndex;
            gvAcknowledgementsResults.DataBind();

            tmrAcknowledgementsResults.Enabled = false;
            pnlAcknowledgementsResults.Visible = false;
        }

        protected void tmrEmployeesResults_Tick(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SearchQuery) && fldsEmployeesResults.Visible)
            {
                gvEmployeesResults.DataSource = searcher.FindUsers(SearchQuery);
                gvEmployeesResults.DataBind();
                fldsEmployeesResults.Visible = true;

                tmrEmployeesResults.Enabled = false;
                pnlEmployeesResults.Visible = false;
            }
        }

        protected void tmrAcknowledgementsResults_Tick(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SearchQuery) && fldsAcknowledgementsResults.Visible)
            {
                gvAcknowledgementsResults.DataSource = searcher.FindAcknowledgements(SearchQuery);
                gvAcknowledgementsResults.DataBind();
                fldsAcknowledgementsResults.Visible = true;

                tmrAcknowledgementsResults.Enabled = false;
                pnlAcknowledgementsResults.Visible = false;
            }
        }

        private void BindGridViews(string search)
        {
            gvEmployeesResults.DataSource = searcher.FindUsers(search);
            gvEmployeesResults.DataBind();
            fldsEmployeesResults.Visible = true;

            gvAcknowledgementsResults.DataSource = searcher.FindAcknowledgements(search);
            gvAcknowledgementsResults.DataBind();
            fldsAcknowledgementsResults.Visible = true;

            pnlAcknowledgementsResults.Visible = false;
            pnlEmployeesResults.Visible = false;
        }
    }
}