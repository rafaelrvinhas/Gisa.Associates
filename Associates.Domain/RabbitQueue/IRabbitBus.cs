namespace Associates.Domain.RabbitQueue
{
    public interface IRabbitBus
    {
        Task SendAsync<T>(string queue, T message);
    }
}
