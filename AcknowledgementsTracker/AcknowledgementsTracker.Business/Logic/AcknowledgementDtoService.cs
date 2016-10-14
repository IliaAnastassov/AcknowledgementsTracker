namespace AcknowledgementsTracker.Business.Logic
{
    using System;
    using DataAccess.Repositories;
    using DTO;
    using Interfaces;

    public class AcknowledgementDtoService : IAcknowledgementDtoService
    {
        private AcknowledgementsRepository repository = new AcknowledgementsRepository();

        public void Create(AcknowledgementDTO dto)
        {
            repository.Add(dto);
        }

        public void Update(AcknowledgementDTO dto)
        {
            repository.Edit(dto);
        }

        public void Delete(int id)
        {
            repository.Remove(id);
        }
    }
}
