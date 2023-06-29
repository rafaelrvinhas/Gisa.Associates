using Associates.Application.Interfaces;
using Associates.Application.Services;
using Associates.Domain.CommandHandlers;
using Associates.Domain.Commands;
using Associates.Domain.Core.Bus;
using Associates.Domain.Core.Notifications;
using Associates.Domain.Interfaces;
using Associates.Infra.CrossCutting.Bus;
using Associates.Infra.Data.Context;
using Associates.Infra.Data.Repository;
using Associates.Infra.Data.UoW;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Associates.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<IAssociateAppService, AssociateAppService>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewAssociateCommand, bool>, AssociateCommandHandler>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Infra - Data
            services.AddScoped<IAssociateRepository, AssociateRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IPlanRepository, PlanRepository>();
            services.AddScoped<IPlanPricingRepository, PlanPricingRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<AssociateContext>();
        }
    }
}