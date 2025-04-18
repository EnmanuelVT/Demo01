namespace Sales.Messages
{
    public class OrderPlaced :
        IEvent
    {
        public string OrderId { get; set; }
    }

}