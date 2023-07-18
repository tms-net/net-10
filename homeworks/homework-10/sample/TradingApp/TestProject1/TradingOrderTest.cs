using TradingApp;

namespace TestProject1
{
    [TestClass]
    public class TradingOrderTest
    {
        
        [TestMethod]
        public void MatchOrderTestWithEqualsOrderInfo()
        {
            // arrange
            OrderInfo orderInfo1 = new OrderInfo()
            {
                Symbol = "MSFT",
                OrderSide = OrderSide.Buy,
                Quantity = 10,
                Price = 100,
            };
            OrderInfo orderInfo2 = new OrderInfo()
            {
                Symbol = "MSFT",
                OrderSide = OrderSide.Sell,
                Quantity = 10,
                Price = 100,
            };
            var tradingOrder = new TradingOrder(orderInfo1, "1", orderInfo2, "2");

            // act
            tradingOrder.MatchOrder(tradingOrder);

            // assert
            
            Assert.AreEqual(OrderStatus.PartiallyCompleted, tradingOrder.Status);
            
        }
        [TestMethod]
        public void MatchOrderTestWithNotEqualsOrderInfo()
        {
            // arrange
            OrderInfo orderInfo1 = new OrderInfo()
            {
                Symbol = "MSFT",
                OrderSide = OrderSide.Buy,
                Quantity = 10,
                Price = 100,
            };
            OrderInfo orderInfo2 = new OrderInfo()
            {
                Symbol = "MSFT",
                OrderSide = OrderSide.Sell,
                Quantity = 10,
                Price = 100,
            };
            var tradingOrder = new TradingOrder(orderInfo1, "1", orderInfo2, "2");

            // act
            tradingOrder.MatchOrder(tradingOrder);

            // assert

            Assert.AreEqual(OrderStatus.PartiallyCompleted, tradingOrder.Status);

        }
    }
}