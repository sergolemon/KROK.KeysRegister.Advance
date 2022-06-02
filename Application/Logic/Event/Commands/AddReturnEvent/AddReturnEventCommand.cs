using Application.Mapping;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic.Event.Commands.AddReturnEvent
{
    public class AddReturnEventCommand : IRequest<Unit>, IMap
    {
        public Guid KeyId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AddReturnEventCommand, EventEntity>();
        }
    }
}
