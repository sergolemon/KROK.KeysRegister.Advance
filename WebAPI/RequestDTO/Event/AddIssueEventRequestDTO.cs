using Application.Logic.Event.Commands.AddIssueEvent;
using Application.Mapping;
using AutoMapper;

namespace WebAPI.RequestDTO.Event
{
    public class AddIssueEventRequestDTO : IMap
    {
        public Guid KeyId { get; set; }
        public Guid? EmployeeId { get; set; }
        public string? Note { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AddIssueEventRequestDTO, AddIssueEventCommand>();
        }
    }
}
