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
        private ILdapAccountService ldapAccountService = new LdapAccountService();
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
            if (!string.IsNullOrWhiteSpace(SearchQuery))
            {
                BindGridViews(SearchQuery);
            }

            SearchTextBox.Focus();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchQuery = SearchTextBox.Value;

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

        protected void ResetBtn_ServerClick(object sender, EventArgs e)
        {
            SearchTextBox.Value = string.Empty;
            SearchQuery = string.Empty;
            fldsEmployeesResults.Visible = false;
            fldsAcknowledgementsResults.Visible = false;
            ErrorLabel.Visible = false;
        }

        protected void EmployeesResultsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            EmployeesResultsGridView.PageIndex = e.NewPageIndex;
            EmployeesResultsGridView.DataBind();
        }

        protected void AcknowledgementsResultsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            AcknowledgementsResultsGridView.PageIndex = e.NewPageIndex;
            AcknowledgementsResultsGridView.DataBind();
        }

        private void BindGridViews(string search)
        {
            EmployeesResultsGridView.DataSource = searcher.FindUsers(search);
            EmployeesResultsGridView.DataBind();
            fldsEmployeesResults.Visible = true;

            AcknowledgementsResultsGridView.DataSource = searcher.FindAcknowledgements(search);
            AcknowledgementsResultsGridView.DataBind();
            fldsAcknowledgementsResults.Visible = true;
        }
    }
}