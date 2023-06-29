using Associates.Application.ViewModels.Enums;
using Associates.Application.ViewModels.Requests;
using Associates.Domain.Commands;
using Associates.Domain.Models.Enums;
using AutoMapper;

namespace Associates.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<NewAssociateViewModel, RegisterNewAssociateCommand>()
                .ConstructUsing(a => new RegisterNewAssociateCommand(
                    a.Name,
                    a.Email,
                    a.DocumentNumber,
                    a.Birthdate,
                    MapGender(a.Gender),
                    a.Address.StreetName,
                    a.Address.Number,
                    a.Address.Complement,
                    a.Address.ZipCode,
                    a.Address.Neighborhood,
                    a.Address.City,
                    a.Address.StateId,
                    MapPlanType(a.Plan.PlanType),
                    MapPlanOption(a.Plan.PlanOption),
                    MapPlanClassification(a.Plan.PlanClassification),
                    a.Plan.ConsultationsConveredPerYear,
                    a.Plan.ExamsCoveredPerYear));
        }

        private static EGender MapGender(EGenderViewModel gender)
        {
            switch (gender)
            {
                case EGenderViewModel.Male: return EGender.Male;
                case EGenderViewModel.Female: return EGender.Female;
                case EGenderViewModel.Uninformed: return EGender.Uninformed;
                default: break;
            }

            return EGender.Uninformed;
        }

        private static EPlanType MapPlanType(EPlanTypeViewModel planType)
        {
            switch (planType)
            {
                case EPlanTypeViewModel.Individual: return EPlanType.Individual;
                case EPlanTypeViewModel.Business: return EPlanType.Business;
                default: break;
            }

            return EPlanType.Individual;
        }

        private static EPlanOption MapPlanOption(EPlanOptionViewModel planType)
        {
            switch (planType)
            {
                case EPlanOptionViewModel.MedicalPlan: return EPlanOption.MedicalPlan;
                case EPlanOptionViewModel.DentalMedicalPlan: return EPlanOption.DentalMedicalPlan;
                default: break;
            }

            return EPlanOption.MedicalPlan;
        }

        private static EPlanClassification MapPlanClassification(EPlanClassificationViewModel planType)
        {
            switch (planType)
            {
                case EPlanClassificationViewModel.Nursery: return EPlanClassification.Nursery;
                case EPlanClassificationViewModel.Apartament: return EPlanClassification.Apartment;
                case EPlanClassificationViewModel.Vip: return EPlanClassification.Vip;
                default: break;
            }

            return EPlanClassification.Nursery;
        }
    }
}
