namespace AcknowledgementsTracker.Business.Logic
{
    using System;
    using System.Collections.Generic;
    using DataAccess.Interfaces;
    using DataAccess.Repositories;
    using DTO;

    public class ModelManager
    {
        private IAcknowledgementsRepository acknowledgementsRepo = new AcknowledgementsRepository();
        private IProxiadEmployeesRepository employeesRepo = new ProxiadEmployeesRepository();
        private ITagsRepository tagsRepo = new TagsRepository();

        public void CreateAcknowledgement(
            int id,
            string text,
            int authorId,
            int beneficiaryId,
            DateTime dateCreated)
        {
            var acknowledgementDto = new AcknowledgementDTO()
            {
                Id = id,
                Text = text,
                AuthorId = authorId,
                BeneficiaryId = beneficiaryId,
                DateCreated = dateCreated,
            };

            acknowledgementsRepo.SaveAcknowledgement(acknowledgementDto);
        }
    }
}
