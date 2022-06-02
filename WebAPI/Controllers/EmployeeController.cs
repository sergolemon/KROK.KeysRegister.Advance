using Application.Logic.Employee.Commands.CreateEmployee;
using Application.Logic.Employee.Commands.DeleteEmployee;
using Application.Logic.Employee.Commands.DeleteEmployeePicture;
using Application.Logic.Employee.Commands.SetEmployeePicture;
using Application.Logic.Employee.Commands.UpdateEmployee;
using Application.Logic.Employee.Queries.FindEmployeesByName;
using Application.Logic.Employee.Queries.GetEmployeeDetails;
using Application.Logic.Employee.Queries.GetEmployees;
using Application.Logic.Employee.Queries.GetEmployeesWithKeysOnly;
using Application.ResponseDTO.Employee;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebAPI.RequestDTO.Employee;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public EmployeeController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> CreateEmployee([FromBody]CreateEmployeeRequestDTO dto)
        {
            CreateEmployeeCommand command = _mapper.Map<CreateEmployeeCommand>(dto);

            return StatusCode(StatusCodes.Status201Created, await _mediator.Send(command));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> UpdateEmployee([FromBody]UpdateEmployeeRequestDTO dto, Guid id)
        {
            UpdateEmployeeCommand command = _mapper.Map<UpdateEmployeeCommand>(dto);
            command.Id = id;

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteEmployee(Guid id)
        {
            DeleteEmployeeCommand command = new DeleteEmployeeCommand
            {
                Id = id
            };

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost("{id}/picture")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> SetEmployeePicture(IFormFile picture, Guid id)
        {
            byte[] buffer = new byte[picture.Length];

            await picture.OpenReadStream().ReadAsync(buffer, 0, (int)picture.Length);

            SetEmployeePictureCommand command = new SetEmployeePictureCommand
            {
                Id = id,
                Picture = buffer
            };

            await _mediator.Send(command);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete("{id}/picture")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteEmployeePicture(Guid id)
        {
            DeleteEmployeePictureCommand command = new DeleteEmployeePictureCommand
            {
                Id = id
            };

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeResponseDTO>> GetEmployees(int? page, int? limit)
        {
            GetEmployeesQuery query = new GetEmployeesQuery();
            if (page.HasValue) query.Page = page.Value;
            if (limit.HasValue) query.Limit = limit.Value;

            return await _mediator.Send(query);
        }

        [HttpGet("with-keys-only")]
        public async Task<IEnumerable<EmployeeResponseDTO>> GetEmployeesWithKeysOnly(int? page, int? limit)
        {
            GetEmployeesWithKeysOnlyQuery query = new GetEmployeesWithKeysOnlyQuery();
            if (page.HasValue) query.Page = page.Value;
            if (limit.HasValue) query.Limit = limit.Value;

            return await _mediator.Send(query);
        }

        [HttpGet("find-by-name")]
        public async Task<IEnumerable<EmployeeResponseDTO>> FindEmployeesByName(string name, int? page, int? limit)
        {
            FindEmployeesByNameQuery query = new FindEmployeesByNameQuery
            {
                Name = name
            };
            if (page.HasValue) query.Page = page.Value;
            if (limit.HasValue) query.Limit = limit.Value;

            return await _mediator.Send(query);
        }

        [HttpGet("{id}")]
        public async Task<EmployeeDetailsResponseDTO> GetEmployeeDetails(Guid id)
        {
            GetEmployeeDetailsQuery query = new GetEmployeeDetailsQuery
            {
                Id = id
            };

            return await _mediator.Send(query);
        }
    }
}
