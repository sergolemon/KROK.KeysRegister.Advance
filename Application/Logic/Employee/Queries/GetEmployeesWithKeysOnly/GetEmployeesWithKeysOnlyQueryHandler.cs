using Application.Interfaces;
using Application.ResponseDTO.Employee;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic.Employee.Queries.GetEmployeesWithKeysOnly
{
    internal class GetEmployeesWithKeysOnlyQueryHandler : IRequestHandler<GetEmployeesWithKeysOnlyQuery, IEnumerable<EmployeeResponseDTO>>
    {
        public GetEmployeesWithKeysOnlyQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        private readonly IUnitOfWork _uow;

        public async Task<IEnumerable<EmployeeResponseDTO>> Handle(GetEmployeesWithKeysOnlyQuery request, CancellationToken cancellationToken)
        {
            return await _uow.EmployeeRepository.GetEmployeesWithKeysOnlyAsync((request.Page - 1) * request.Limit, request.Limit);
        }
    }
}
