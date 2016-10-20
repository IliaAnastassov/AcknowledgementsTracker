namespace AcknowledgementsTracker.Presentation
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Business.Logic;
    using System.Data;
    using DTO;

    public partial class Dashboard : System.Web.UI.Page
    {
        private string username;
        private AcknowledgementDtoService acknowledgementService = new AcknowledgementDtoService();

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
            var userAcknowledgements = acknowledgementService.Read(username);
            UserAcknowledgementsGridView.DataSource = userAcknowledgements;
            UserAcknowledgementsGridView.DataBind();

            // Bind last acknowledgements
            var lastAcknowledgements = acknowledgementService.ReadLast();
            LastAcknowledgemetsGridView.DataSource = lastAcknowledgements;
            LastAcknowledgemetsGridView.DataBind();
        }

        protected void AcknowledgementsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var acknowledgement = e.Row.DataItem as AcknowledgementDTO;
                var ltrTags = e.Row.FindControl("ltrTags") as Literal;
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