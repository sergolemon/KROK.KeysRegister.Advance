using Application.Mapping;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic.Employee.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommand : IRequest<Unit>, IMap
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }

        public UpdateEmployeeCommand()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Patronymic = string.Empty;
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateEmployeeCommand, EmployeeEntity>();
        }
    }
}
