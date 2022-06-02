using Application.Interfaces;
using Application.ResponseDTO.Employee;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic.Employee.Queries.FindEmployeesByName
{
    internal class FindEmployeesByNameQueryHandler : IRequestHandler<FindEmployeesByNameQuery, IEnumerable<EmployeeResponseDTO>>
    {
        public FindEmployeesByNameQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        private readonly IUnitOfWork _uow;

        public async Task<IEnumerable<EmployeeResponseDTO>> Handle(FindEmployeesByNameQuery request, CancellationToken cancellationToken)
        {
            return await _uow.EmployeeRepository.FindEmployeesByNameAsync((request.Page - 1) * request.Limit, request.Limit, request.Name);
        }
    }
}
