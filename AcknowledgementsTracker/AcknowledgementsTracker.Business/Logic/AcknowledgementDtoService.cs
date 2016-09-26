namespace AcknowledgementsTracker.Business.Logic
{
    using System;
    using DataAccess.Repositories;
    using DTO;

    public class AcknowledgementDtoService
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
