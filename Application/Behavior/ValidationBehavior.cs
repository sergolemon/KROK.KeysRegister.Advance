using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Behavior
{
    internal class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            IEnumerable<ValidationFailure> fails = _validators
                .Select(v => v.Validate(request))
                .Where(res => !res.IsValid)
                .SelectMany(res => res.Errors);

            if (fails.Any())
                throw new ValidationException(fails);

            return await next();
        }
    }
}
