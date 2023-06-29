using Associates.Domain.Commands;
using FluentValidation;

namespace Associates.Domain.Validations
{
    public abstract class AssociateValidation<T> : AbstractValidator<T> where T : AssociateCommand
    {
        protected void ValidateEmail()
        {
            RuleFor(a => a.Email)
                .NotEmpty().WithMessage("O e-mail deve ser informado.");
        }
    }
}
