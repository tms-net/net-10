namespace TradingApp
{
    public class DealDetails
    {
        public IReadOnlyList<OrderFulfillmentInfo> OrderFulfillments { get; set; }
        public IOrder OrderReference { get; set; }
    }

    public class OrderFulfillmentInfo
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public IOrder OrderReference { get; set; }
    }
}

