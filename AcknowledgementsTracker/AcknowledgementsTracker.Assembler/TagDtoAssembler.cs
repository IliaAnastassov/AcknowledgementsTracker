namespace AcknowledgementsTracker.Assembler
{
    using System.Collections.Generic;
    using DTO;
    using Model;

    public class TagDtoAssembler : BaseAssembler<Tag, TagDTO>
    {
        private DtoSubCollectionAssembler collectionAssembler = new DtoSubCollectionAssembler();

        public override TagDTO Assemble(Tag entity)
        {
            if (entity == null)
            {
                return null;
            }

            var dto = new TagDTO();

            dto.Id = entity.TagId;
            dto.Title = entity.Title;

            return dto;
        }

        public override Tag Disassemble(TagDTO dto)
        {
            if (dto == null)
            {
                return null;
            }

            var entity = new Tag();

            entity.TagId = dto.Id;
            entity.Title = dto.Title;

            return entity;
        }
    }
}
