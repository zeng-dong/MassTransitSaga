using MassTransit;
using MassTransitSaga.Messages;
using Serilog;
using System.Threading.Tasks;

namespace InventoryService.Consumers
{
    public class PaymentCardNumberValidateConsumer : IConsumer<ISubmitOrder>
    {
        public async Task Consume(ConsumeContext<ISubmitOrder> context)
        {
            if (context.Message.PaymentCardNumber.StartsWith("good"))
            {
                Log.Warning("Good payment card: {@ISubmitOrder}", context.Message);
            }
            else
            {
                Log.Warning("Bad payment card: {@ISubmitOrder}", context.Message);
            }
        }
    }
}
