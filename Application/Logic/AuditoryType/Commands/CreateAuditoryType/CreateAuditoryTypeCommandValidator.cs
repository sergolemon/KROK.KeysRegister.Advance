using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic.AuditoryType.Commands.CreateAuditoryType
{
    public class CreateAuditoryTypeCommandValidator : AbstractValidator<CreateAuditoryTypeCommand>
    {
        public CreateAuditoryTypeCommandValidator()
        {
            RuleFor(src => src.Name);
        }
    }
}
