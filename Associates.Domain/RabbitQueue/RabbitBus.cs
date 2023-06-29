using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Associates.Domain.RabbitQueue
{
    public class RabbitBus : IRabbitBus
    {
        private readonly IModel _channel;

        internal RabbitBus(IModel channel)
        {
            _channel = channel;
        }

        public async Task SendAsync<T>(string queue, T message)
        {
            await Task.Run(() =>
            {
                _channel.QueueDeclare(
                    queue: queue, 
                    durable: false, 
                    exclusive: false, 
                    autoDelete: false,
                    arguments: null);

                //var properties = _channel.CreateBasicProperties();
                //properties.Persistent = false;

                var body = JsonSerializer.Serialize(message);

                _channel.BasicPublish(
                    exchange: string.Empty, 
                    routingKey: queue, 
                    basicProperties: null, 
                    body: Encoding.UTF8.GetBytes(body));
            });
        }
    }
}
