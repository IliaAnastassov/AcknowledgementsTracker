namespace AcknowledgementsTracker.Business.Logic
{
    using System;
    using DataAccess.Repositories;
    using DTO;

    public class EmployeeDtoService
    {
        private EmployeesRepository repository = new EmployeesRepository();

        public void Create(EmployeeDTO dto)
        {
            repository.Add(dto);
        }

        public void Update(EmployeeDTO dto)
        {
            repository.Edit(dto);
        }

        public void Delete(int id)
        {
            repository.Remove(id);
        }
    }
}
