using Application.ResponseDTO.Key;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic.Key.Queries.GetKeyDetails
{
    public class GetKeyDetailsQuery : IRequest<KeyDetailsResponseDTO>
    {
        public Guid Id { get; set; }
    }
}
