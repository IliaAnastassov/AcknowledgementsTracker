namespace AcknowledgementsTracker.Assembler
{
    using DTO.Interfaces;
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public abstract class BaseAssembler<From, To> : IAssembler<From, To>
        where From : new()
        where To : IDto, new()
    {
        public BaseAssembler()
        {
        }

        public abstract To Assemble(From entity);

        public abstract From Disassemble(To dto);

        public IEnumerable<To> AssembleCollection(IEnumerable<From> entities)
        {
            foreach (var entity in entities)
            {
                yield return Assemble(entity);
            }
        }

        public IEnumerable<From> DisassembleCollection(IEnumerable<To> dtos)
        {
            foreach (var dto in dtos)
            {
                yield return Disassemble(dto);
            }
        }
    }
}
