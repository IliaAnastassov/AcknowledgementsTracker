﻿namespace AcknowledgementsTracker.Business.Interfaces
{
    using System.Collections.Generic;
    using DTO;

    public interface IAcknowledgementDtoService : IDtoService
    {
        void Create(AcknowledgementDTO dto, IEnumerable<string> tags);

        IEnumerable<AcknowledgementDTO> ReadReceived(string username);

        IEnumerable<AcknowledgementDTO> ReadGiven(string username);

        IEnumerable<AcknowledgementDTO> ReadLast();

        IEnumerable<AcknowledgementDTO> ReadTodays();

        IEnumerable<AcknowledgementDTO> ReadThisWeek();

        IEnumerable<AcknowledgementDTO> ReadThisMonth();

        string ReadAllTimeChampion();

        Dictionary<string, int> ReadAllTimeTopTen();

        Dictionary<string, int> ReadThisMonthTopTen();

        void Update(AcknowledgementDTO dto);
    }
}
