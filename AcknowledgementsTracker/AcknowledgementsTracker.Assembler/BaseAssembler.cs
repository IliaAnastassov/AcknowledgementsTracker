namespace AcknowledgementsTracker.Assembler
{
    using DTO.Interfaces;
    using System;
    using System.Collections.Generic;

    public abstract class BaseAssembler<From, To>
        where From : new()
        where To : IDto, new()
    {
        public BaseAssembler()
        {
        }

        public abstract To Assemble(From entity);

        public abstract From Disassemble(To entity);

        public IEnumerable<To> AssembleCollection(IEnumerable<From> entities)
        {
            foreach (var entity in entities)
            {
                yield return Assemble(entity);
            }
        }

        public IEnumerable<From> DisassembleCollection(IEnumerable<To> entities)
        {
            foreach (var entity in entities)
            {
                yield return Disassemble(entity);
            }
        }
    }
}
