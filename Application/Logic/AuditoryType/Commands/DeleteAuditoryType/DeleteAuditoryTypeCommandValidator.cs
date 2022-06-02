using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic.AuditoryType.Commands.DeleteAuditoryType
{
    public class DeleteAuditoryTypeCommandValidator : AbstractValidator<DeleteAuditoryTypeCommand>
    {
        public DeleteAuditoryTypeCommandValidator()
        {
            RuleFor(src => src.Id);
        }
    }
}
