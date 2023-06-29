using Associates.Domain.Commands;
using Associates.Domain.Core.Bus;
using Associates.Domain.Core.Notifications;
using Associates.Domain.Interfaces;
using Associates.Domain.Models;
using Associates.Domain.Models.ValueObjects;
using Associates.Domain.RabbitQueue;
using Associates.Domain.RabbitQueue.Models;
using MediatR;

namespace Associates.Domain.CommandHandlers
{
    public class AssociateCommandHandler : CommandHandler, IRequestHandler<RegisterNewAssociateCommand, bool>
    {
        private readonly IAssociateRepository _associateRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IPlanPricingRepository _planPricingRepository;
        private readonly IPlanRepository _planRepository;
        private readonly IMediatorHandler Bus;
        private readonly IRabbitBus _rabbitBus;

        public AssociateCommandHandler(
            IAssociateRepository associateRepository,
            IAddressRepository addressRepository,
            IPlanPricingRepository planPricingRepository,
            IPlanRepository planRepository,
            IUnitOfWork uow,
            IMediatorHandler bus,
            IRabbitBus rabbitBus,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, rabbitBus, notifications)
        {
            _associateRepository = associateRepository;
            _addressRepository = addressRepository;
            _planPricingRepository = planPricingRepository;
            _planRepository = planRepository;
            _rabbitBus = rabbitBus;
            Bus = bus;
        }

        public async Task<bool> Handle(RegisterNewAssociateCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return false;
            }

            if (_associateRepository.GetByDocumentNumber(message.DocumentNumber) != null)
            {
                await Bus.RaiseEvent(new DomainNotification(message.MessageType, "Já existe um associado com o CPF informado."));
                return false;
            }

            int age = GetNewAssociateAge(message.Birthdate);
            var planPricing = _planPricingRepository.GetPlanPricing(
                age, 
                (int)message.PlanType, 
                (int)message.PlanOption, 
                (int)message.PlanClassification);

            if (planPricing is null) return false;

            var plan = new Plan(
                DateTime.Now.AddYears(1), 
                message.PlanOption, 
                message.PlanClassification, 
                message.PlanType, 
                planPricing.Id, 
                message.ConsultationsConveredPerYear, 
                message.ExamsCoveredPerYear);

            var address = new Address(
                message.StreetName, 
                message.Number, 
                message.Complement, 
                message.ZipCode, 
                message.Neighborhood, 
                message.City, 
                message.StateId);

            var associate = new Associate(
                message.Name, 
                message.Email, 
                message.DocumentNumber, 
                message.Birthdate, 
                message.Gender, 
                message.AssociateCategory, 
                address, 
                plan);
            
            var associateAddress = _addressRepository.Add(address);
            var associatePlan = _planRepository.Add(plan);

            associate.AddressId = associateAddress.Id;
            associate.PlanId = associatePlan.Id;

            _associateRepository.Add(associate);

            if (Commit())
            {
                //Disponibilizando informações na fila de novos associados
                var associateIdentification = new AssociateIdentification(
                    associate.Id,
                    associate.Email, 
                    associate.DocumentNumber,
                    (int)associate.AssociateCategory,
                    associate.Plan.Id);

                await _rabbitBus.SendAsync("NewAssociateQueue", associateIdentification);

                //Disponibilizando informações na fila do plano do novo associado
                var associatePlanInfo = new AssociatePlanInfo(
                    associate.Id, 
                    associate.Plan.Id, 
                    (int)associate.Plan.PlanClassification,  
                    (int)associate.Plan.PlanOption, 
                    (int)associate.Plan.PlanType, 
                    associate.Plan.PlanExpirationDate.ToString("yyyy-MM-dd"));

                await _rabbitBus.SendAsync("AssociatePlanInfoQueue", associatePlanInfo);
            }

            return true;
        }

        public void Dispose()
        {
            _associateRepository.Dispose();
        }

        private int GetNewAssociateAge(DateTime birthdate)
        {
            DateTime zeroTime = new DateTime(1, 1, 1);
            TimeSpan span = DateTime.Now - birthdate;
            return (zeroTime + span).Year - 1;
        }
    }
}
