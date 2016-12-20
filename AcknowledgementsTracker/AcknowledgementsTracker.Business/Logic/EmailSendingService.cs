namespace AcknowledgementsTracker.Business.Logic
{
    using System;
    using System.Net;
    using System.Net.Mail;
    using Interfaces;
    using Ressources;

    public class EmailSendingService : IEmailSendingService
    {
        public void SendEmail(IUser author, IUser beneficiary)
        {
            var template = new ASP._RazorTemplates_EmailTemplate_cshtml
            {
                AuthorName = author.Name,
                BeneficiaryName = beneficiary.Name
            };

            var emailContent = template.TransformText();

            SmtpClient smtpClient = new SmtpClient(BusinessResources.SMTPServer, Convert.ToInt32(BusinessResources.SMTPPort));
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Credentials = new NetworkCredential();
            smtpClient.EnableSsl = true;
            smtpClient.Timeout = 20000;

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(BusinessResources.SMTPEmailAddress);
            mail.To.Add(new MailAddress(beneficiary.Email));
            mail.Subject = "New acknowledgement received";
            mail.Body = emailContent;

            smtpClient.Send(mail);
        }
    }
}
