using Application.Mapping;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic.Event.Commands.AddIssueEvent
{
    public class AddIssueEventCommand : IRequest<Unit>, IMap
    {
        public string? Note { get; set; }
        public Guid KeyId { get; set; }
        public Guid? EmployeeId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AddIssueEventCommand, EventEntity>();
        }
    }
}
