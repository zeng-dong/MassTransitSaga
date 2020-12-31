using MassTransit;
using MassTransitSaga.Configuration;
using MassTransitSaga.Messages;
using Microsoft.AspNetCore.Mvc;
using OrderService.ViewModels;
using System;
using System.Threading.Tasks;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public OrdersController(ISendEndpointProvider sendEndpointProvider)
        {
            _sendEndpointProvider = sendEndpointProvider;
        }

        [HttpPost]
        [Route("createorder")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderModel orderModel)
        {
            var endPoint = await _sendEndpointProvider.
                GetSendEndpoint(new Uri("queue:" + RabbitMqConstants.OrderQueue));

            await endPoint.Send<ISubmitOrder>(new
            {
                orderModel.OrderId,
                //orderModel.ProductName,
                PaymentCardNumber = orderModel.CardNumber,

                CustomerName = orderModel.UserId,
                Timestamp = InVar.Timestamp
            });

            return Ok("Success");
        }
    }
}
