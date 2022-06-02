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

namespace Application.Logic.Employee.Commands.DeleteEmployee
{
    internal class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Unit>
    {
        public DeleteEmployeeCommandHandler(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            if (!await _uow.EmployeeRepository.CheckEmployeeExistenceByIdAsync(request.Id))
                throw new NotFoundException(request.Id);

            EmployeeEntity entity = _mapper.Map<EmployeeEntity>(request);

            _uow.EmployeeRepository.DeleteEmployee(entity);
            await _uow.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
