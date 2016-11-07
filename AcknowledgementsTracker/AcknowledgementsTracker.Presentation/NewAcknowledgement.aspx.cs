namespace AcknowledgementsTracker.Presentation
{
    using System;
    using System.Web.UI;
    using Business.Interfaces;
    using Business.Logic;
    using DTO;
    using DTO.Interfaces;
    using System.Web;

    public partial class NewAcknowledgement : Page
    {
        private IAcknowledgementDtoService acknowledgementDtoService = new AcknowledgementDtoService();
        private ITagDtoService tagDtoService = new TagDtoService();
        private ILdapAccountService ldapAccountService = new LdapAccountService();
        private UIHelper helper = new UIHelper();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["beneficiary"] != null)
            {
                BeneficiaryTextBox.Value = helper.GetUserFullName(Request.QueryString["beneficiary"]);
                ContentTextBox.Focus();
            }
            else
            {
                BeneficiaryTextBox.Focus();
            }
        }

        protected void CreateNewAcknowledgementBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(BeneficiaryTextBox.Value)
                && !string.IsNullOrWhiteSpace(ContentTextBox.Value)
                && !string.IsNullOrWhiteSpace(TagsTextBox.Value))
            {
                INormalizable textNormalizer = new TextNormalizationService();
                var acknowledgementDto = new AcknowledgementDTO();
                acknowledgementDto.AuthorUsername = HttpContext.Current.User.Identity.Name;

                // Transform full name to username
                acknowledgementDto.BeneficiaryUsername = ldapAccountService.ReadUserUsername(BeneficiaryTextBox.Value);

                // Store the text and normalize it
                acknowledgementDto.Text = textNormalizer.RemoveMultiSpaces(ContentTextBox.Value);
                acknowledgementDto.NormalizedText = textNormalizer.NormalizeText(acknowledgementDto.Text);

                // NOTE: All tags are stored in lowercase
                var tags = TagsTextBox.Value.ToLower().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                // Add acknowledgement to database
                acknowledgementDtoService.Create(acknowledgementDto, tags);

                // Clear all entries if necessary
                if (Request.QueryString["beneficiary"] == null)
                {
                    BeneficiaryTextBox.Value = string.Empty;
                }
                ContentTextBox.Value = string.Empty;
                TagsTextBox.Value = string.Empty;

                lblError.Visible = false;
                lblSuccess.Visible = true;
            }
            else
            {
                lblError.Visible = true;
                lblSuccess.Visible = false;
            }
        }

        protected void ResetBtn_ServerClick(object sender, EventArgs e)
        {
            BeneficiaryTextBox.Value = string.Empty;
            ContentTextBox.Value = string.Empty;
            TagsTextBox.Value = string.Empty;

            lblError.Visible = false;
            lblSuccess.Visible = false;
        }
    }
}