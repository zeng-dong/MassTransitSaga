namespace MassTransitSaga.Configuration
{
    public class RabbitMqConstants
    {
        public const string HostString = "amqp://guest:guest@localhost:5672";
        public const string RabbitMqUri = "rabbitmq://localhost/";
        public const string UserName = "guest";
        public const string Password = "guest";
        public const string OrderQueue = "grocery-order-queue";
    }
}
