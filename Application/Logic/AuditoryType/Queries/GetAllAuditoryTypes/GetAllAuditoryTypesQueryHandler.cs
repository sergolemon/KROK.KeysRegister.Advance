using Application.Interfaces;
using Application.ResponseDTO.AuditoryType;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic.AuditoryType.Queries.GetAllAuditoryTypes
{
    internal class GetAllAuditoryTypesQueryHandler : IRequestHandler<GetAllAuditoryTypesQuery, IEnumerable<AuditoryTypeResponseDTO>>
    {
        public GetAllAuditoryTypesQueryHandler(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public async Task<IEnumerable<AuditoryTypeResponseDTO>> Handle(GetAllAuditoryTypesQuery request, CancellationToken cancellationToken)
        {
            return await _uow.AuditoryTypeRepository.GetAllAuditoryTypesAsync();
        }
    }
}
