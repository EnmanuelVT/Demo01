namespace Billing.Messages
{
    public class OrderBilled : IEvent
    {
        public string OrderId { get; set; }
    }
}
