using Application.Mapping;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic.AuditoryType.Commands.UpdateAuditoryType
{
    public class UpdateAuditoryTypeCommand : IRequest<Unit>, IMap
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public UpdateAuditoryTypeCommand()
        {
            Name = string.Empty;
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateAuditoryTypeCommand, AuditoryTypeEntity>();
        }
    }
}
