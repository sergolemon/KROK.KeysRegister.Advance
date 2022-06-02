using Application.Logic.Permission.Commands.AddPermission;
using Application.Logic.Permission.Commands.RemovePermission;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebAPI.RequestDTO.Permission;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        public PermissionController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> AddPermission([FromBody]AddPermissionRequestDTO dto)
        {
            AddPermissionCommand command = _mapper.Map<AddPermissionCommand>(dto);

            await _mediator.Send(command);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> RemovePermission([FromBody]RemovePermissionRequestDTO dto)
        {
            RemovePermissionCommand command = _mapper.Map<RemovePermissionCommand>(dto);

            await _mediator.Send(command);

            return StatusCode(StatusCodes.Status204NoContent);
        }

    }
}
