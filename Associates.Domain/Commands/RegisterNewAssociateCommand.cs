using Associates.Domain.Models.Enums;
using Associates.Domain.Validations;

namespace Associates.Domain.Commands
{
    public class RegisterNewAssociateCommand : AssociateCommand
    {
        public RegisterNewAssociateCommand(
            string name, 
            string email, 
            string documentNumber, 
            DateTime birthdate, 
            EGender gender,
            string streetName,
            string number,
            string complement,
            string zipCode,
            string neighborhood,
            string city,
            int stateId,
            EPlanType planType,
            EPlanOption planOption,
            EPlanClassification planClassification,
            int consultationsConveredPerYear,
            int examsCoveredPerYear)
        {
            Name = name;
            Email = email;
            DocumentNumber = documentNumber;
            Birthdate = birthdate;
            Gender = gender;
            AssociateCategory = EAssociateCategory.Active;
            StreetName = streetName;
            Number = number;
            Complement = complement;
            ZipCode = zipCode;
            Neighborhood = neighborhood;
            City = city;
            StateId = stateId;
            PlanType = planType;
            PlanOption = planOption;
            PlanClassification = planClassification;
            ConsultationsConveredPerYear = consultationsConveredPerYear;
            ExamsCoveredPerYear = examsCoveredPerYear;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewAssociateCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }   
    }
}
