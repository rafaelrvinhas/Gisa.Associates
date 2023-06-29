using Associates.Domain.Commands;

namespace Associates.Domain.Validations
{
    public class RegisterNewAssociateCommandValidation : AssociateValidation<RegisterNewAssociateCommand>
    {
        public RegisterNewAssociateCommandValidation()
        {
            ValidateEmail();
        }
    }
}
