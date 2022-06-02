using Application.Mapping;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic.AuditoryType.Commands.CreateAuditoryType
{
    public class CreateAuditoryTypeCommand : IRequest<Guid>, IMap
    {
        public string Name { get; set; }

        public CreateAuditoryTypeCommand()
        {
            Name = string.Empty;
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateAuditoryTypeCommand, AuditoryTypeEntity>();
        }
    }
}
