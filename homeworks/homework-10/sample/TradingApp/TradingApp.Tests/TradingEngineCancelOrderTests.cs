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

			var isSuccessful = tradingEngine.CancelOrder(orderId);

			Assert.AreEqual(true, isSuccessful);
		}

		[TestMethod]
		public void CancelOrderByIdShouldReturnFalseForUnexistingId()
		{
            var tradingEngine = new TradingEngine();
			var orderId = "test_id";

            var isSuccessful = tradingEngine.CancelOrder(orderId);

			Assert.AreEqual(false, isSuccessful);
        }
    }
}

