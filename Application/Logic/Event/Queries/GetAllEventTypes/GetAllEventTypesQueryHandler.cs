using Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic.Event.Queries.GetAllEventTypes
{
    internal class GetAllEventTypesQueryHandler : IRequestHandler<GetAllEventTypesQuery, IEnumerable<string>>
    {
        public Task<IEnumerable<string>> Handle(GetAllEventTypesQuery request, CancellationToken cancellationToken)
        {
            return Task.Run(() => typeof(EventTypeConst)
                .GetFields()
                .Select(field => field.GetRawConstantValue()!.ToString()!)
            );
        }
    }
}
