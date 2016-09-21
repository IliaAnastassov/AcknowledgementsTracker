namespace AcknowledgementsTracker.Assembler
{
    using System;
    using DTO;
    using Model;

    public class EmployeeDtoAssembler : BaseAssembler<Employee, EmployeeDTO>
    {
        public override EmployeeDTO Assemble(Employee entity)
        {
            if (entity == null)
            {
                return null;
            }

            var dto = new EmployeeDTO();

            dto.Id = entity.EmployeeId;
            dto.AcknowledgementsGiven = entity.AcknowledgementsGiven;
            dto.AcknowledgementsReceived = entity.AcknowledgementsReceived;
            dto.Email = entity.Email;
            dto.UserName = entity.UserName;

            return dto;
        }

        public override Employee Disassemble(EmployeeDTO entity)
        {
            if (entity == null)
            {
                return null;
            }

            var proxiadEmployee = new Employee();

            proxiadEmployee.EmployeeId = entity.Id;
            proxiadEmployee.AcknowledgementsGiven = entity.AcknowledgementsGiven;
            proxiadEmployee.AcknowledgementsReceived = entity.AcknowledgementsReceived;
            proxiadEmployee.Email = entity.Email;
            proxiadEmployee.UserName = entity.UserName;

            return proxiadEmployee;
        }
    }
}
