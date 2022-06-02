using Application.Filters.Event;
using Application.Mapping;
using Application.ResponseDTO.Event;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic.Event.Queries.GetEvents
{
    public class GetEventsQuery : IRequest<IEnumerable<EventResponseDTO>>, IMap
    {
        public Guid? KeyId { get; set; }
        public Guid? EmployeeId { get; set; }
        public DateTime? MinDateTime { get; set; }
        public DateTime? MaxDateTime { get; set; }
        public string? Type { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }

        public GetEventsQuery()
        {
            Page = 1;
            Limit = 10;
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetEventsQuery, EventFilters>();
        }
    }
}
