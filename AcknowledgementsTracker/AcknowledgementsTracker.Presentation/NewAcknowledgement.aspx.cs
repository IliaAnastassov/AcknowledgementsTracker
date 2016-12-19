namespace AcknowledgementsTracker.Presentation
{
    using System;
    using System.Web;
    using System.Web.UI;
    using Business.Interfaces;
    using Business.Logic;
    using DTO;
    using System.Net.Mail;

    public partial class NewAcknowledgement : Page
    {
        private IAcknowledgementDtoService acknowledgementDtoService = new AcknowledgementDtoService();
        private ITagDtoService tagDtoService = new TagDtoService();
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
                    if (Request.QueryString[Global.Beneficiary] != null)
                    {
                        acknowledgementDto.BeneficiaryUsername = Request.QueryString[Global.Beneficiary];

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

                    // Send an email to beneficiary
                    SendBeneficiaryEmail(acknowledgementDto.BeneficiaryUsername);

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

        private void SendBeneficiaryEmail(string beneficiaryUsername)
        {
            // TODO:
            SmtpClient smtpClient = new SmtpClient("mail.MyWebsiteDomainName.com", 25);

            smtpClient.Credentials = new System.Net.NetworkCredential("info@MyWebsiteDomainName.com", "myIDPassword");
            smtpClient.UseDefaultCredentials = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            MailMessage mail = new MailMessage();

            //Setting From , To and CC
            mail.From = new MailAddress("info@MyWebsiteDomainName", "MyWeb Site");
            mail.To.Add(new MailAddress("info@MyWebsiteDomainName"));
            mail.CC.Add(new MailAddress("MyEmailID@gmail.com"));

            smtpClient.Send(mail);
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