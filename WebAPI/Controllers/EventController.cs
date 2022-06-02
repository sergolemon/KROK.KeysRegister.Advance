using Application.Logic.Event.Commands.AddIssueEvent;
using Application.Logic.Event.Commands.AddReturnEvent;
using Application.Logic.Event.Queries.GetAllEventTypes;
using Application.Logic.Event.Queries.GetEvents;
using Application.ResponseDTO.Event;
using AutoMapper;
using Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebAPI.RequestDTO.Event;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        public EventController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        [HttpPost("issue")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> AddIssueEvent([FromBody]AddIssueEventRequestDTO dto)
        {
            AddIssueEventCommand command = _mapper.Map<AddIssueEventCommand>(dto);

            await _mediator.Send(command);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost("return")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> AddReturnEvent([FromForm]Guid keyId)
        {
            AddReturnEventCommand command = new AddReturnEventCommand 
            {
                KeyId = keyId
            };

            await _mediator.Send(command);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        public async Task<IEnumerable<EventResponseDTO>> GetEvents(int? page, int? limit, [FromQuery]EventFiltersRequestDTO dto)
        {
            GetEventsQuery query = _mapper.Map<GetEventsQuery>(dto);
            if(page.HasValue) query.Page = page.Value;
            if(limit.HasValue) query.Limit = limit.Value;

            return await _mediator.Send(query);

        }

        [HttpGet("/api/event-type")]
        public async Task<IEnumerable<string>> GetAllEventTypes()
        {
            return await _mediator.Send(new GetAllEventTypesQuery());
        }
    }
}
