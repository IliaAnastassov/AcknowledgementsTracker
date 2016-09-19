namespace AcknowledgementsTracker.Assembler
{
    using System;
    using DTO;
    using Model;

    public class ProxiadEmployeeDtoAssembler : BaseAssembler<ProxiadEmployee, ProxiadEmployeeDTO>
    {
        public override ProxiadEmployeeDTO Assemble(ProxiadEmployee entity)
        {
            if (entity == null)
            {
                return null;
            }

            var dto = new ProxiadEmployeeDTO();

            dto.Id = entity.Id;
            dto.AcknowledgementsGiven = entity.AcknowledgementsGiven;
            dto.AcknowledgementsReceived = entity.AcknowledgementsReceived;
            dto.Email = entity.Email;
            dto.UserName = entity.UserName;

            return dto;
        }

        public override ProxiadEmployee Disassemble(ProxiadEmployeeDTO entity)
        {
            if (entity == null)
            {
                return null;
            }

            var proxiadEmployee = new ProxiadEmployee();

            proxiadEmployee.Id = entity.Id;
            proxiadEmployee.AcknowledgementsGiven = entity.AcknowledgementsGiven;
            proxiadEmployee.AcknowledgementsReceived = entity.AcknowledgementsReceived;
            proxiadEmployee.Email = entity.Email;
            proxiadEmployee.UserName = entity.UserName;

            return proxiadEmployee;
        }
    }
}
