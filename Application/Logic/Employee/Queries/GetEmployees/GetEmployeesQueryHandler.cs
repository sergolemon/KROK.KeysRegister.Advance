using Application.Interfaces;
using Application.ResponseDTO.Employee;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic.Employee.Queries.GetEmployees
{
    internal class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, IEnumerable<EmployeeResponseDTO>>
    {
        public GetEmployeesQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        private readonly IUnitOfWork _uow;

        public async Task<IEnumerable<EmployeeResponseDTO>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            return await _uow.EmployeeRepository.GetEmployeesAsync((request.Page - 1) * request.Limit, request.Limit);
        }
    }
}
