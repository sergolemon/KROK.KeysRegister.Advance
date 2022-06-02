using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic.AuditoryType.Commands.UpdateAuditoryType
{
    public class UpdateAuditoryTypeCommandValidator : AbstractValidator<UpdateAuditoryTypeCommand>
    {
        public UpdateAuditoryTypeCommandValidator()
        {
            RuleFor(src => src.Id);
        }
    }
}
