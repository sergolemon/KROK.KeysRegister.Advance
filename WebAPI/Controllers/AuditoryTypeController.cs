using Application.Logic.AuditoryType.Commands.CreateAuditoryType;
using Application.Logic.AuditoryType.Commands.DeleteAuditoryType;
using Application.Logic.AuditoryType.Commands.UpdateAuditoryType;
using Application.Logic.AuditoryType.Queries.GetAllAuditoryTypes;
using Application.ResponseDTO.AuditoryType;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/auditory-type")]
    [ApiController]
    public class AuditoryTypeController : ControllerBase
    {
        public AuditoryTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private readonly IMediator _mediator;

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> CreateAuditoryType([FromForm]string name)
        {
            CreateAuditoryTypeCommand command = new CreateAuditoryTypeCommand
            {
                Name = name 
            };

            return StatusCode(StatusCodes.Status201Created, await _mediator.Send(command));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> UpdateAuditoryType([FromForm]string name, Guid id)
        {
            UpdateAuditoryTypeCommand command = new UpdateAuditoryTypeCommand
            {
                Id = id,
                Name = name
            };

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteAuditoryType(Guid id)
        {
            DeleteAuditoryTypeCommand command = new DeleteAuditoryTypeCommand
            {
                Id = id
            };

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpGet]
        public async Task<IEnumerable<AuditoryTypeResponseDTO>> GetAllAuditoryTypes()
        {
            return await _mediator.Send(new GetAllAuditoryTypesQuery());
        }
    }
}
