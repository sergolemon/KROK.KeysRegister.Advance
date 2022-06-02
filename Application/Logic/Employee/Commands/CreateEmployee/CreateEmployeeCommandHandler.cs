using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic.Employee.Commands.CreateEmployee
{
    internal class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
    {
        public CreateEmployeeCommandHandler(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            EmployeeEntity entity = _mapper.Map<EmployeeEntity>(request);
            entity.Id = Guid.NewGuid();

            _uow.EmployeeRepository.CreatEmployee(entity);
            await _uow.SaveChangesAsync();

            return entity.Id;
        }
    }
}
