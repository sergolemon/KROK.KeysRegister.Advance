using Application.Mapping;
using Application.ResponseDTO.Employee;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic.Employee.Queries.FindEmployeesByName
{
    public class FindEmployeesByNameQuery : IRequest<IEnumerable<EmployeeResponseDTO>>
    {
        public string Name { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }

        public FindEmployeesByNameQuery()
        {
            Name = string.Empty;
            Page = 1;
            Limit = 10;
        }
    }
}
