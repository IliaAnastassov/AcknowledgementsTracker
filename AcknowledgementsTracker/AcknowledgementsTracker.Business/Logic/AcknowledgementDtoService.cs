namespace AcknowledgementsTracker.Business.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using DataAccess.Repositories;
    using DTO;
    using Interfaces;

    public class AcknowledgementDtoService : IAcknowledgementDtoService
    {
        private AcknowledgementsRepository repository = new AcknowledgementsRepository();

        public void Create(AcknowledgementDTO dto, IEnumerable<string> tags)
        {
            repository.Add(dto, tags);
        }

        public IEnumerable<AcknowledgementDTO> Read(string username)
        {
            return repository.GetAcknowledgements(username).ToList();
        }

        public IEnumerable<AcknowledgementDTO> ReadLast()
        {
            return repository.GetLastAcknowledgements().ToList();
        }

        public IEnumerable<AcknowledgementDTO> ReadTodays()
        {
            return repository.GetTodaysAcknowledgements().ToList();
        }

        public IEnumerable<AcknowledgementDTO> ReadThisWeek()
        {
            return repository.GetThisWeekAcknowledgements().ToList();
        }

        public IEnumerable<AcknowledgementDTO> ReadThisMonth()
        {
            return repository.GetThisMonthAcknowledgements().ToList();
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
