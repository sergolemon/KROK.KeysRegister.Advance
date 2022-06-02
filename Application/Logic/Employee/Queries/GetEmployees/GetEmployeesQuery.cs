using Application.ResponseDTO.Employee;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic.Employee.Queries.GetEmployees
{
    public class GetEmployeesQuery : IRequest<IEnumerable<EmployeeResponseDTO>>
    {
        public int Page { get; set; }
        public int Limit { get; set; }

        public GetEmployeesQuery()
        {
            Page = 1;
            Limit = 10;
        }
    }
}
