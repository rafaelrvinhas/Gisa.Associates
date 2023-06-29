using Associates.Domain.Core.Bus;
using Associates.Domain.Core.Commands;
using Associates.Domain.Core.Notifications;
using Associates.Domain.Interfaces;
using Associates.Domain.RabbitQueue;
using MediatR;

namespace Associates.Domain.CommandHandlers
{
    public class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMediatorHandler _bus;
        private readonly IRabbitBus _rabbitBus;
        private readonly DomainNotificationHandler _notifications;

        public CommandHandler(IUnitOfWork uow, IMediatorHandler bus, IRabbitBus rabbitBus, INotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            _notifications = (DomainNotificationHandler)notifications;
            _bus = bus;
            _rabbitBus = rabbitBus;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                //_bus.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
            }
        }

        public bool Commit()
        {
            //if (_notifications.HasNotifications()) return false;
            if (_uow.Commit()) return true;

            return false;
        }
    }
}
