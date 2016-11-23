namespace AcknowledgementsTracker.Presentation
{
    using System;
    using System.Web;
    using System.Web.UI;
    using Business.Interfaces;
    using Business.Logic;
    using DTO;

    public partial class NewAcknowledgement : Page
    {
        private IAcknowledgementDtoService acknowledgementDtoService = new AcknowledgementDtoService();
        private ITagDtoService tagDtoService = new TagDtoService();
        private IAccountService ldapAccountService = new LdapAccountService();
        private UIHelper helper = new UIHelper();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["beneficiary"] != null)
            {
                txtbBeneficiary.Value = helper.GetUserFullName(Request.QueryString["beneficiary"]);
                txtbContent.Focus();
            }
            else
            {
                txtbBeneficiary.Focus();
            }
        }

        protected void btnCreateNewAcknowledgement_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtbBeneficiary.Value)
                && !string.IsNullOrWhiteSpace(txtbContent.Value)
                && !string.IsNullOrWhiteSpace(txtbTags.Value))
            {
                INormalizable textNormalizer = new TextNormalizationService();
                var acknowledgementDto = new AcknowledgementDTO();
                acknowledgementDto.AuthorUsername = HttpContext.Current.User.Identity.Name;

                try
                {
                    if (Request.QueryString["beneficiary"] != null)
                    {
                        acknowledgementDto.BeneficiaryUsername = Request.QueryString["beneficiary"];

                        // If the user changes the beneficiary to a new value
                        if (!string.IsNullOrWhiteSpace(hfUserUsername.Value))
                        {
                            acknowledgementDto.BeneficiaryUsername = hfUserUsername.Value;
                        }
                    }
                    else if (!string.IsNullOrWhiteSpace(hfUserUsername.Value))
                    {
                        acknowledgementDto.BeneficiaryUsername = hfUserUsername.Value;
                    }
                    else
                    {
                        // Transform full name to username
                        acknowledgementDto.BeneficiaryUsername = ldapAccountService.ReadUserUsername(txtbBeneficiary.Value.Trim());
                        txtbBeneficiary.Value = string.Empty;
                    }

                    // Store the text and normalize it
                    acknowledgementDto.Text = txtbContent.Value;
                    acknowledgementDto.NormalizedText = textNormalizer.NormalizeText(acknowledgementDto.Text);

                    // NOTE: All tags are stored in lowercase
                    var tags = txtbTags.Value.ToLower().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                    // Add acknowledgement to database
                    acknowledgementDtoService.Create(acknowledgementDto, tags);

                    txtbContent.Value = string.Empty;
                    txtbTags.Value = string.Empty;

                    Response.Redirect(Global.DashboardPage);
                }
                catch (ArgumentException ex)
                {
                    lblError.Visible = true;
                    lblError.InnerText = ex.Message;
                }
            }
        }

        protected void btnReset_ServerClick(object sender, EventArgs e)
        {
            txtbContent.Value = string.Empty;
            txtbTags.Value = string.Empty;

            if (Request.QueryString["beneficiary"] == null)
            {
                txtbBeneficiary.Value = string.Empty;
                txtbBeneficiary.Focus();
            }
            else
            {
                txtbContent.Focus();
            }

            lblError.Visible = false;
        }
    }
}