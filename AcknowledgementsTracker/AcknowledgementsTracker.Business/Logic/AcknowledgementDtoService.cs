namespace AcknowledgementsTracker.Business.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using DataAccess.Repositories;
    using DTO;
    using Interfaces;
    using DataAccess.Interfaces;

    public class AcknowledgementDtoService : IAcknowledgementDtoService
    {
        private IAcknowledgementsRepository repository;

        public AcknowledgementDtoService()
        {
            repository = new AcknowledgementsRepository();
        }

        public AcknowledgementDtoService(IAcknowledgementsRepository repository)
        {
            this.repository = repository;
        }

        public void Create(AcknowledgementDTO dto, IEnumerable<string> tags)
        {
            repository.Add(dto, tags);
        }

        public IEnumerable<AcknowledgementDTO> ReadReceived(string username)
        {
            return repository.GetReceived(username);
        }

        public IEnumerable<AcknowledgementDTO> ReadGiven(string username)
        {
            return repository.GetGiven(username);
        }

        public IEnumerable<AcknowledgementDTO> ReadLast()
        {
            return repository.GetLastAcknowledgements();
        }

        public IEnumerable<AcknowledgementDTO> ReadTodays()
        {
            return repository.GetTodaysAcknowledgements();
        }

        public IEnumerable<AcknowledgementDTO> ReadThisWeek()
        {
            return repository.GetThisWeekAcknowledgements();
        }

        public IEnumerable<AcknowledgementDTO> ReadThisMonth()
        {
            return repository.GetThisMonthAcknowledgements();
        }

        public string ReadAllTimeChampion()
        {
            return repository.GetAllTimeChampion();
        }

        public Dictionary<string, int> ReadAllTimeTopTen()
        {
            return repository.GetAllTimeTopTen();
        }

        public Dictionary<string, int> ReadThisMonthTopTen()
        {
            return repository.GetThisMonthTopTen();
        }

        public IEnumerable<AcknowledgementDTO> ReadReceivedThisMonth(string username)
        {
            return repository.GetThisMonthsByUser(username);
        }

        public IEnumerable<AcknowledgementDTO> ReadByTag(string tagTitle)
        {
            return repository.GetByTag(tagTitle);
        }

        public IEnumerable<AcknowledgementDTO> ReadByTagThisMonth(string tagTitle)
        {
            return repository.GetByTagThisMonth(tagTitle);
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
