﻿namespace AcknowledgementsTracker.Business.Logic
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

        public IEnumerable<AcknowledgementDTO> ReadReceived(string username)
        {
            return repository.GetReceived(username).ToList();
        }

        public IEnumerable<AcknowledgementDTO> ReadGiven(string username)
        {
            return repository.GetGiven(username).ToList();
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

        public Dictionary<string, int> ReadTopTenByTag(string tagTitle)
        {
            return repository.GetTopTenByTag(tagTitle);
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
