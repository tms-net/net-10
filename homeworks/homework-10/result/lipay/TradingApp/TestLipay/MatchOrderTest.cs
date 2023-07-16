using TradingApp;

namespace TestLipay
{
    [TestClass]
    public class MatchOrderTest
    {
        [TestMethod]
        public void MatchOrderTest1()
        {
            // arrange
            OrderInfo orderInfo = new OrderInfo
            {
                Symbol = "MSFT",
                OrderSide = OrderSide.Buy,
                Quantity = 100,
                Price = 10
            };
            var tradingOrder = new TradingOrder(orderInfo);

            // act
            tradingOrder.MatchOrder(tradingOrder);

            // assert
            Assert.Equals(orderInfo, tradingOrder);
      
        }
    }
}