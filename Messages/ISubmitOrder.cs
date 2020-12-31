using System;

namespace MassTransitSaga.Messages
{
    public interface ISubmitOrder
    {
        public Guid OrderId { get; }
        public string PaymentCardNumber { get; set; }
        public string CustomerName { get; }
        public DateTime Timestamp { get; }
    }
}
