using Application.Logic.Event.Queries.GetEvents;
using Application.Mapping;
using AutoMapper;

namespace WebAPI.RequestDTO.Event
{
    public class EventFiltersRequestDTO : IMap
    {
        public Guid? KeyId { get; set; }
        public Guid? EmployeeId { get; set; }
        public DateTime? MinDateTime { get; set; }
        public DateTime? MaxDateTime { get; set; }
        public string? Type { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<EventFiltersRequestDTO, GetEventsQuery>();
        }
    }
}
