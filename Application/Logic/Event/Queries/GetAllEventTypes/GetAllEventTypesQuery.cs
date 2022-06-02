using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic.Event.Queries.GetAllEventTypes
{
    public class GetAllEventTypesQuery : IRequest<IEnumerable<string>>
    {
    }
}
