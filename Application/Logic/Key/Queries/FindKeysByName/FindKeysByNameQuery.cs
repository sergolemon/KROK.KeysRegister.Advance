using Application.ResponseDTO.Key;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic.Key.Queries.FindKeysByName
{
    public class FindKeysByNameQuery : IRequest<IEnumerable<KeyResponseDTO>>
    {
        public string Name { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }

        public FindKeysByNameQuery()
        {
            Name = string.Empty;
            Page = 1;
            Limit = 10;
        }
    }
}
