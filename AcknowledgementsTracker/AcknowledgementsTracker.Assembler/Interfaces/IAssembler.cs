namespace AcknowledgementsTracker.Assembler.Interfaces
{
    using System.Collections.Generic;

    public interface IAssembler<From, To>
    {
        To Assemble(From entity);

        From Disassemble(To dto);

        IEnumerable<To> AssembleCollection(IEnumerable<From> entities);

        IEnumerable<From> DisassembleCollection(IEnumerable<To> dtos);
    }
}
