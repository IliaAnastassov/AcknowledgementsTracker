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
        private IEmailSendingService emailSender = new EmailSendingService();
        private IAccountService ldapAccountService;
        private UIHelper helper;

        protected void Page_Load(object sender, EventArgs e)
        {
            var connection = (ILdapServerConnection)Session[Global.LdapConnection];
            helper = new UIHelper(connection);
            ldapAccountService = new LdapAccountService();
            ldapAccountService.SetAccountManager(connection);

            if (Request.QueryString[Global.Beneficiary] != null)
            {
                txtbBeneficiary.Value = helper.GetUserFullName(Request.QueryString[Global.Beneficiary]);
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
                    if (!string.IsNullOrWhiteSpace(hfUserUsername.Value))
                    {
                        acknowledgementDto.BeneficiaryUsername = hfUserUsername.Value;
                    }
                    else if (Request.QueryString[Global.Beneficiary] != null)
                    {
                        acknowledgementDto.BeneficiaryUsername = Request.QueryString[Global.Beneficiary];
                    }
                    else
                    {
                        // Transform full name to username
                        acknowledgementDto.BeneficiaryUsername = ldapAccountService.ReadUserUsername(txtbBeneficiary.Value.Trim());
                        txtbBeneficiary.Value = string.Empty;
                    }

                    CreateAcknowledgement(textNormalizer, acknowledgementDto);

                    SendBeneficiaryEmail(acknowledgementDto.AuthorUsername, acknowledgementDto.BeneficiaryUsername);

                    ClearAndRedirect();
                }
                catch (ArgumentException ex)
                {
                    lblError.Visible = true;
                    lblError.InnerText = ex.Message;
                }
                // TODO: Remove
                catch (Exception ex)
                {
                    lblError.Visible = true;
                    lblError.InnerText = ex.Message;
                }
            }
        }

        private void ClearAndRedirect()
        {
            txtbContent.Value = string.Empty;
            txtbTags.Value = string.Empty;

            Response.Redirect(Global.DashboardPage);
        }

        private void CreateAcknowledgement(INormalizable textNormalizer, AcknowledgementDTO acknowledgementDto)
        {
            acknowledgementDto.Text = txtbContent.Value;
            acknowledgementDto.NormalizedText = textNormalizer.NormalizeText(acknowledgementDto.Text);

            // NOTE: All tags are stored in lowercase
            var tags = txtbTags.Value.ToLower().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            acknowledgementDtoService.Create(acknowledgementDto, tags);
        }

        private void SendBeneficiaryEmail(string authorUsername, string beneficiaryUsername)
        {
            var author = ldapAccountService.ReadUserData(authorUsername);
            var beneficiary = ldapAccountService.ReadUserData(beneficiaryUsername);

            emailSender.SendEmail(author, beneficiary);
        }

        protected void btnReset_ServerClick(object sender, EventArgs e)
        {
            txtbContent.Value = string.Empty;
            txtbTags.Value = string.Empty;

            if (Request.QueryString[Global.Beneficiary] == null)
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