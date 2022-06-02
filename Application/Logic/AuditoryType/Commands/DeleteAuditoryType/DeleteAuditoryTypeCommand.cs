using Application.Mapping;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic.AuditoryType.Commands.DeleteAuditoryType
{
    public class DeleteAuditoryTypeCommand : IRequest<Unit>, IMap
    {
        public Guid Id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DeleteAuditoryTypeCommand, AuditoryTypeEntity>();
        }
    }
}
