using Application.Logic.Key.Commands.CreateKey;
using Application.Mapping;
using AutoMapper;

namespace WebAPI.RequestDTO.Key
{
    public class CreateKeyRequestDTO : IMap
    {
        public string Name { get; set; }
        public Guid AuditoryTypeId { get; set; }

        public CreateKeyRequestDTO()
        {
            Name = string.Empty;
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateKeyRequestDTO, CreateKeyCommand>();
        }
    }
}
