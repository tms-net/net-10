namespace TradingApp.Tests.Doubles
{
    internal class FakeOrderEngine : ITradingEngine
    {
        Dictionary<string, OrderInfo> _storage = new Dictionary<string, OrderInfo>();

        public event Action<string, OrderInfo> OrderMatched;

        public void CancelOrder(string orderId)
        {
            if (_storage.ContainsKey(orderId))
            {
                throw new InvalidOperationException();
            }
        }

        public string CreateOrder(OrderInfo orderInfo)
        {
            var orderId = _storage.Count.ToString();
            _storage.Add(orderId, orderInfo);

            return orderId;
        }
    }
}
