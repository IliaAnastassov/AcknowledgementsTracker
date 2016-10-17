namespace AcknowledgementsTracker.Assembler
{
    using System;
    using System.Collections.Generic;
    using DTO;
    using Model;
    using System.Collections.ObjectModel;

    public class DtoSubCollectionAssembler
    {
        public IEnumerable<AcknowledgementDTO> AssembleSubCollection(ICollection<Acknowledgement> acknowledgements)
        {
            ICollection<AcknowledgementDTO> acknowledgementDtos = new Collection<AcknowledgementDTO>();

            foreach (var entity in acknowledgements)
            {
                if (entity == null)
                {
                    continue;
                }

                var dto = new AcknowledgementDTO();

                dto.Id = entity.AcknowledgementId;
                dto.AuthorUsername = entity.AuthorUsername;
                dto.DateCreated = entity.DateCreated;
                dto.Text = entity.Text;

                acknowledgementDtos.Add(dto);
            }

            return acknowledgementDtos;
        }

        public IEnumerable<TagDTO> AssembleSubCollection(ICollection<Tag> tags)
        {
            ICollection<TagDTO> tagDtos = new Collection<TagDTO>();

            foreach (var entity in tags)
            {
                if (entity == null)
                {
                    continue;
                }

                var dto = new TagDTO();

                dto.Id = entity.TagId;
                dto.Title = entity.Title;

                tagDtos.Add(dto);
            }

            return tagDtos;
        }

        public IEnumerable<Acknowledgement> DisassembleSubCollection(ICollection<AcknowledgementDTO> acknowledgementDtos)
        {
            ICollection<Acknowledgement> acknowledgements = new Collection<Acknowledgement>();

            foreach (var dto in acknowledgementDtos)
            {
                if (dto == null)
                {
                    continue;
                }

                var entity = new Acknowledgement();

                entity.AcknowledgementId = dto.Id;
                entity.AuthorUsername = dto.AuthorUsername;
                entity.BeneficiaryUsername = dto.BeneficiaryUsername;
                entity.DateCreated = dto.DateCreated;
                entity.Text = dto.Text;

                acknowledgements.Add(entity);
            }

            return acknowledgements;
        }

        public IEnumerable<Tag> DisassembleSubCollection(ICollection<TagDTO> tagDtos)
        {
            ICollection<Tag> tags = new Collection<Tag>();

            foreach (var dto in tagDtos)
            {
                if (dto == null)
                {
                    continue;
                }

                var entity = new Tag();

                entity.TagId = dto.Id;
                entity.Title = dto.Title;

                tags.Add(entity);
            }

            return tags;
        }
    }
}
