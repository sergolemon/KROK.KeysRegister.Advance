using Application.Mapping;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic.Key.Commands.DeleteKey
{
    public class DeleteKeyCommand : IRequest<Unit>, IMap
    {
        public Guid Id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DeleteKeyCommand, KeyEntity>();
        }
    }
}
