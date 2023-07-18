using System;
namespace TradingApp.Tests
{
	[TestClass]
	public class TradingEngineCancelOrderTests
	{
		[TestMethod]
        public void CancelOrderByIdSouldCancelProcessingOrder()
		{
			var tradingEngine = new TradingEngine();
			var orderId = tradingEngine.CreateOrder(TradingOrder.CreateOrderWithStatus(OrderStatus.Processing).OrderInfo);

			tradingEngine.CancelOrder(orderId);

			
		}
    }
}

