using Application.Exceptions;
using Application.Interfaces;
using Application.ResponseDTO.Employee;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic.Employee.Queries.GetEmployeeDetails
{
    internal class GetEmployeeDetailsQueryHandler : IRequestHandler<GetEmployeeDetailsQuery, EmployeeDetailsResponseDTO>
    {
        public GetEmployeeDetailsQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        private readonly IUnitOfWork _uow;

        public async Task<EmployeeDetailsResponseDTO> Handle(GetEmployeeDetailsQuery request, CancellationToken cancellationToken)
        {
            EmployeeDetailsResponseDTO? response = await _uow.EmployeeRepository.GetEmployeeDetailsOrNullAsync(request.Id);

            if (response == null) throw new NotFoundException(request.Id);

            return response;
        }
    }
}
