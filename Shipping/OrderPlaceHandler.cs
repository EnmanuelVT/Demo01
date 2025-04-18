using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Sales.Messages;
using Billing.Messages;

namespace Shipping
{
    public class OrderPlacedHandler(ILogger<OrderPlacedHandler> logger) :
IHandleMessages<OrderPlaced>
    {
        public Task Handle(OrderPlaced message, IMessageHandlerContext context)
        {
            logger.LogInformation("Received OrderPlaced, should we ship now?: {orderId}", message.OrderId);

            return Task.CompletedTask;
        }
    }
}
