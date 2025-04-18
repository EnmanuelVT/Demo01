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
    public class OrderBilledHandler(ILogger<OrderBilledHandler> logger) : IHandleMessages<OrderBilled>
    {
        public Task Handle(OrderBilled message, IMessageHandlerContext context)
        {
            logger.LogInformation("Received OrderBilled, should we ship now?: {orderId}", message.OrderId);

            return Task.CompletedTask;
        }
    }
}
