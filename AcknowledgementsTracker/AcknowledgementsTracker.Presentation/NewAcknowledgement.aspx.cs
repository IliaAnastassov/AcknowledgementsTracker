namespace AcknowledgementsTracker.Presentation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Business.Interfaces;
    using Business.Logic;
    using DTO;
    using DTO.Interfaces;

    public partial class NewAcknowledgement : System.Web.UI.Page
    {
        private IAcknowledgementDtoService acknowledgementDtoService = new AcknowledgementDtoService();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateNewFormBtn_Click(object sender, EventArgs e)
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

                acknowledgementDto.Tags.Add(tagDto);
            }

            // TODO:
        }
    }
}