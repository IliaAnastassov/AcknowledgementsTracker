namespace AcknowledgementsTracker.Presentation
{
    using System;
    using System.Web.UI;
    using Business.Interfaces;
    using Business.Logic;
    using DTO;
    using DTO.Interfaces;
    using System.Web;
    using System.Threading;

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

                if (Request.QueryString["beneficiary"] != null)
                {
                    acknowledgementDto.BeneficiaryUsername = Request.QueryString["beneficiary"];
                }
                else
                {
                    // Transform full name to username
                    acknowledgementDto.BeneficiaryUsername = ldapAccountService.ReadUserUsername(txtbBeneficiary.Value);
                }

                // Store the text and normalize it
                acknowledgementDto.Text = textNormalizer.RemoveMultiSpaces(txtbContent.Value);
                acknowledgementDto.NormalizedText = textNormalizer.NormalizeText(acknowledgementDto.Text);

                // NOTE: All tags are stored in lowercase
                var tags = txtbTags.Value.ToLower().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                // Add acknowledgement to database
                acknowledgementDtoService.Create(acknowledgementDto, tags);

                // Clear all entries if necessary
                if (Request.QueryString["beneficiary"] == null)
                {
                    txtbBeneficiary.Value = string.Empty;
                }
                txtbContent.Value = string.Empty;
                txtbTags.Value = string.Empty;

                lblError.Visible = false;
                lblSuccess.Visible = true;
            }
            else
            {
                lblError.Visible = true;
                lblSuccess.Visible = false;
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
            lblSuccess.Visible = false;
        }
    }
}