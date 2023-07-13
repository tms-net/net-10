namespace TradingApp.Tests.Doubles
{
    internal class StubTradingEngine : ITradingEngine
    {
        public event Action<string, OrderInfo> OrderMatched;

        public void CancelOrder(string orderId)
        {
            if (orderId != "orderId")
            {
                throw new InvalidOperationException();
            }
        }

        public string CreateOrder(OrderInfo orderInfo)
        {
            return "orderId";
        }
    }
}
