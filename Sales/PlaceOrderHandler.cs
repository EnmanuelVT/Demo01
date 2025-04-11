using Messages;
using Microsoft.Extensions.Logging;

namespace ClientUI
{
    public class PlaceOrderHandler(ILogger<PlaceOrderHandler> logger) :
        IHandleMessages<PlaceOrder>
    {
        public Task Handle(PlaceOrder message, IMessageHandlerContext context)
        {
            // Testear excepciones
            // throw new Exception("Boom");
            logger.LogInformation(
                "Received PlaceOrder, OrderId = {orderId}", message.OrderId);

            return Task.CompletedTask;
        }
    }
}
