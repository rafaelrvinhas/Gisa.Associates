using Associates.Application.ViewModels.Responses;
using Associates.Domain.Models;
using Associates.Domain.Models.ValueObjects;
using AutoMapper;

namespace Associates.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Associate, AssociateDetailsViewModel>();
            CreateMap<Plan, PlanDetailsViewModel>();
            CreateMap<PlanPricingTable, PlanPricingTableViewModel>();
            CreateMap<Address, AddressDetailsViewModel>();
            CreateMap<State, StateViewModel>();
        }
    }
}
