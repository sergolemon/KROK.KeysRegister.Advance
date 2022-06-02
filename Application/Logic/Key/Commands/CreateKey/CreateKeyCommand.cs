using Application.Mapping;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic.Key.Commands.CreateKey
{
    public class CreateKeyCommand : IRequest<Guid>, IMap
    {
        public string Name { get; set; }
        public Guid AuditoryTypeId { get; set; }

        public CreateKeyCommand()
        {
            Name = string.Empty;
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateKeyCommand, KeyEntity>();
        }
    }
}
