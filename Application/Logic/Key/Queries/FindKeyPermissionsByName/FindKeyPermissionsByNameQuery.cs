using Application.ResponseDTO.Key;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic.Key.Queries.FindKeyPermissionsByName
{
    public class FindKeyPermissionsByNameQuery : IRequest<IEnumerable<KeyPermissionResponseDTO>>
    {
        public Guid EmployeeId { get; set; }
        public string Name { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }

        public FindKeyPermissionsByNameQuery()
        {
            Name = string.Empty;
            Page = 1;
            Limit = 10;
        }
    }
}
