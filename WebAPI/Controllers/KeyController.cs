using Application.Logic.Key.Commands.CreateKey;
using Application.Logic.Key.Commands.DeleteKey;
using Application.Logic.Key.Commands.UpdateKey;
using Application.Logic.Key.Queries.FindKeyPermissionsByName;
using Application.Logic.Key.Queries.FindKeysByName;
using Application.Logic.Key.Queries.GetKeyDetails;
using Application.Logic.Key.Queries.GetKeyPermissions;
using Application.Logic.Key.Queries.GetKeyPermissionsFreeOnly;
using Application.Logic.Key.Queries.GetKeys;
using Application.Logic.Key.Queries.GetKeysFreeOnly;
using Application.ResponseDTO.Key;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebAPI.RequestDTO.Key;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyController : ControllerBase
    {
        public KeyController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> CreateKey([FromBody]CreateKeyRequestDTO dto)
        {
            CreateKeyCommand command = _mapper.Map<CreateKeyCommand>(dto);

            return StatusCode(StatusCodes.Status201Created, await _mediator.Send(command));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> UpdateKey([FromBody]UpdateKeyRequestDTO dto, Guid id)
        {
            UpdateKeyCommand command = _mapper.Map<UpdateKeyCommand>(dto);
            command.Id = id;

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteKey(Guid id)
        {
            DeleteKeyCommand command = new DeleteKeyCommand 
            {
                Id = id
            };

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpGet]
        public async Task<IEnumerable<KeyResponseDTO>> GetKeys(int? page, int? limit, Guid? auditoryTypeId)
        {
            GetKeysQuery query = new GetKeysQuery();
            query.AuditoryTypeId = auditoryTypeId;
            if (page.HasValue) query.Page = page.Value;
            if (limit.HasValue) query.Limit = limit.Value;

            return await _mediator.Send(query);
        }

        [HttpGet("find-by-name")]
        public async Task<IEnumerable<KeyResponseDTO>> FindKeysByName(int? page, int? limit, string name)
        {
            FindKeysByNameQuery query = new FindKeysByNameQuery();
            query.Name = name;
            if (page.HasValue) query.Page = page.Value;
            if (limit.HasValue) query.Limit = limit.Value;

            return await _mediator.Send(query);
        }

        [HttpGet("free-only")]
        public async Task<IEnumerable<KeyResponseDTO>> GetKeysFreeOnly(int? page, int? limit, Guid? auditoryTypeId)
        {
            GetKeysFreeOnlyQuery query = new GetKeysFreeOnlyQuery();
            query.AuditoryTypeId = auditoryTypeId;
            if (page.HasValue) query.Page = page.Value;
            if (limit.HasValue) query.Limit = limit.Value;

            return await _mediator.Send(query);
        }

        [HttpGet("{id}")]
        public async Task<KeyDetailsResponseDTO> GetKeyDetails(Guid id)
        {
            GetKeyDetailsQuery query = new GetKeyDetailsQuery 
            {
                Id = id
            };

            return await _mediator.Send(query);
        }

        [HttpGet("/api/key-permission")]
        public async Task<IEnumerable<KeyPermissionResponseDTO>> GetKeyPermissions(int? page, int? limit, Guid empId, Guid? auditoryTypeId)
        {
            GetKeyPermissionsQuery query = new GetKeyPermissionsQuery();
            query.EmployeeId = empId;
            query.AuditoryTypeId = auditoryTypeId;
            if (page.HasValue) query.Page = page.Value;
            if (limit.HasValue) query.Limit = limit.Value;

            return await _mediator.Send(query);
        }

        [HttpGet("/api/key-permission/find-by-name")]
        public async Task<IEnumerable<KeyPermissionResponseDTO>> FindKeyPermissionsByName(int? page, int? limit, Guid empId, string name)
        {
            FindKeyPermissionsByNameQuery query = new FindKeyPermissionsByNameQuery();
            query.EmployeeId = empId;
            query.Name = name;
            if (page.HasValue) query.Page = page.Value;
            if (limit.HasValue) query.Limit = limit.Value;

            return await _mediator.Send(query);
        }

        [HttpGet("/api/key-permission/free-only")]
        public async Task<IEnumerable<KeyPermissionResponseDTO>> GetKeyPermissionsFreeOnly(int? page, int? limit, Guid empId, Guid? auditoryTypeId)
        {
            GetKeyPermissionsFreeOnlyQuery query = new GetKeyPermissionsFreeOnlyQuery();
            query.EmployeeId = empId;
            query.AuditoryTypeId = auditoryTypeId;
            if (page.HasValue) query.Page = page.Value;
            if (limit.HasValue) query.Limit = limit.Value;

            return await _mediator.Send(query);
        }
    }
}
