using Application.Mapping;
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
    public class CreateEmployeeCommand : IRequest<Guid>, IMap
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }

        public CreateEmployeeCommand()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Patronymic = string.Empty;
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateEmployeeCommand, EmployeeEntity>();
        }
    }
}
