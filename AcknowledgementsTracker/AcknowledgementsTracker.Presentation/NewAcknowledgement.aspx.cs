namespace AcknowledgementsTracker.Presentation
{
    using System;
    using System.Web.UI;
    using Business.Interfaces;
    using Business.Logic;
    using DTO;
    using DTO.Interfaces;

    public partial class NewAcknowledgement : Page
    {
        private IAcknowledgementDtoService acknowledgementDtoService = new AcknowledgementDtoService();
        private ITagDtoService tagDtoService = new TagDtoService();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void CreateNewAcknowledgementBtn_Click(object sender, EventArgs e)
        {
            var acknowledgementDto = new AcknowledgementDTO();
            acknowledgementDto.AuthorUsername = LdapAccountManager.Instance.Username;
            acknowledgementDto.BeneficiaryUsername = BeneficiaryTextBox.Value;
            acknowledgementDto.Text = ContentTextBox.Value;

            var tags = TagsTextBox.Value.Split();

            foreach (var tag in tags)
            {
                var tagDto = new TagDTO();
                tagDto.Title = tag;
                tagDto.Acknowledgements.Add(acknowledgementDto);

                // Add tag to database
                tagDtoService.Create(tagDto);

                acknowledgementDto.Tags.Add(tagDto);
            }

            // Add acknowledgement to database
            acknowledgementDtoService.Create(acknowledgementDto);

            // Clear all entries
            BeneficiaryTextBox.Value = string.Empty;
            ContentTextBox.Value = string.Empty;
            TagsTextBox.Value = string.Empty;
        }
    }
}