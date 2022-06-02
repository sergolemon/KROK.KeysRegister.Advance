using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic.Employee.Commands.UpdateEmployee
{
    internal class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Unit>
    {
        public UpdateEmployeeCommandHandler(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            if (!await _uow.EmployeeRepository.CheckEmployeeExistenceByIdAsync(request.Id))
                throw new NotFoundException(request.Id);

            EmployeeEntity entity = _mapper.Map<EmployeeEntity>(request);

            _uow.EmployeeRepository.UpdateEmployee(entity);
            await _uow.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
