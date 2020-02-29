using System;
using FluentValidation;

namespace Mailbox.Cleaner.Domain.Requests.RequestsValidations
{
    public class ImportRequestValidation : AbstractValidator<ImportRequest>
    {
        public ImportRequestValidation()
        {
            RuleFor(request => request.Server).NotEmpty();
            RuleFor(request => request.Port).NotEmpty();
            RuleFor(request => request.Username).EmailAddress().NotEmpty();
            RuleFor(request => request.Password).NotEmpty();
        }
    }
}
