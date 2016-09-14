namespace AcknowledgementsTracker.Business
{
    using System.Collections.Generic;
    using Model.Models;
    using DataAccess.Interfaces;
    using DataAccess.Repositories;

    public class AcknowledgementManager
    {
        public void CreateAcknowledgement(string text, int authorId, int beneficiaryId, ICollection<Tag> tags)
        {
            var acknowledgement = new Acknowledgement
            {
                Text = text,
                AuthorId = authorId,
                BeneficiaryId = beneficiaryId,
                Tags = tags
            };

            IAcknowledgementsRepository acknowledgementsRepo = new AcknowledgementsRepository();
            acknowledgementsRepo.SaveAcknowledgement(acknowledgement);
        }
    }
}
