namespace AcknowledgementsTracker.Business.Logic
{
    using System.Collections.Generic;
    using Model;
    using DataAccess.Interfaces;
    using DataAccess.Repositories;

    public class ModelManager
    {
        IAcknowledgementsRepository acknowledgementsRepo = new AcknowledgementsRepository();
        IProxiadEmployeesRepository employeesRepo = new ProxiadEmployeesRepository();
        ITagsRepository tagsRepo = new TagsRepository();

        public void CreateAcknowledgement(string text, int authorId, int beneficiaryId, ICollection<Tag> tags)
        {
            var acknowledgement = new Acknowledgement
            {
                Text = text,
                AuthorId = authorId,
                BeneficiaryId = beneficiaryId,
                Tags = tags
            };

            acknowledgementsRepo.SaveAcknowledgement(acknowledgement);
        }
    }
}
