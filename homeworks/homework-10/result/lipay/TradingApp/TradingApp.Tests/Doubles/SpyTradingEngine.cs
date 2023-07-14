namespace TradingApp.Tests.Doubles
{
    internal class SpyTradingEngine : ITradingEngine
    {
        private readonly ITradingEngine _tradingEngine;

        private int _cancelOrderCallCounter;
        private int _createOrderCallCounter;

        public SpyTradingEngine(ITradingEngine tradingEngine)
        {
            _tradingEngine = tradingEngine;
        }

        public event Action<string, OrderInfo> OrderMatched;

        public void CancelOrder(string orderId)
        {
            _cancelOrderCallCounter++;
            _tradingEngine.CancelOrder(orderId);
        }

        public string CreateOrder(OrderInfo orderInfo)
        {
            _createOrderCallCounter++;
            return _tradingEngine.CreateOrder(orderInfo);
        }
    }
}
