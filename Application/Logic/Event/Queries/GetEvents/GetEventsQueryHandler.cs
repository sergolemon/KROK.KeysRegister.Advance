using Application.Filters.Event;
using Application.Interfaces;
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
    internal class GetEventsQueryHandler : IRequestHandler<GetEventsQuery, IEnumerable<EventResponseDTO>>
    {
        public GetEventsQueryHandler(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public async Task<IEnumerable<EventResponseDTO>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
        {
            return await _uow.EventRepository.GetEventsAsync((request.Page - 1) * request.Limit, request.Limit, _mapper.Map<EventFilters>(request));
        }
    }
}
