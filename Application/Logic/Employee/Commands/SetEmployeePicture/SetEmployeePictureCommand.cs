using Application.Mapping;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Application.Logic.Employee.Commands.SetEmployeePicture
{
    public class SetEmployeePictureCommand : IRequest<Unit>, IMap
    {
        public Guid Id { get; set; }
        public byte[] Picture { get; set; }

        public SetEmployeePictureCommand()
        {
            Picture = null!;
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SetEmployeePictureCommand, EmployeeEntity>();
        }
    }
}
