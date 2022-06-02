using Application.ResponseDTO.Employee;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic.Employee.Queries.GetEmployeeDetails
{
    public class GetEmployeeDetailsQuery : IRequest<EmployeeDetailsResponseDTO>
    {
        public Guid Id { get; set; }
    }
}
