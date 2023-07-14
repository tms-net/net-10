namespace TradingApp.Tests
{
    [TestClass]
    public class TradingOrderTests
    {
        private TradingOrder[] _pendingOrders;

        // TDD - Test Driven Development

        // xUnit
        // NUnit
        // MSTest

        // Method -> Should -> When


        [TestInitialize]
        public void TestInitialize()
        {
        }

        [TestCleanup]
        public void TestCleanup()
        {
        }

        [TestMethod]
        public void CancelOrderShouldCancelPendingOrder()
        {
            // arrange
            // создание контекста/ входных параметров
            // создание объекта и определение значений параметров метода
            // тестируемый объект называется
            //  - sut (system under test)
            //  - subject
            //var now = DateTime.UtcNow;
            var order = new TradingOrder();

            // act
            // совершение тестируемого действия
            // вызов нужного метода
            order.CancelOrder();

            // assert
            // проверка ожиданий
            // проверка выходных значений

            // expected value
            // actual value
            Assert.AreEqual(OrderStatus.Cancelled, order.Status);

            // CollectionAssert.DoesNotContain(arry, 1);

            //StringAssert.Contains();

            //Assert.IsTrue();

            // Assert.AreEqual(1, array.Count(elem => elem == 3))

            //Assert.GreaterThan(now, order.Date);
        }

        // public OrderStatus[] StatusDataSource => new[] { OrderStatus.Processing, OrderStatus.PartiallyCompleted } 

        [TestMethod]
        // [DataSource("StatusDataSource")]
        [DataRow(OrderStatus.Processing)]
        [DataRow(OrderStatus.PartiallyCompleted)]
        [DataRow(OrderStatus.Completed)]
        [DataRow(OrderStatus.Cancelled)]
        //[DoNotParallelize]
        public void CancelOrderShouldNotCancelCompletedOrder(
            // [DataSource("StatusDataSource")] 
            OrderStatus status)
            //, [DataSource("PriceDataSource")]  decimal price)
        {
            // Test cases

            // Mock

            // arrange
            var order = TradingOrder.CreateOrderWithStatus(status);


            // assert
            Assert.ThrowsException<InvalidOperationException>(
                () =>
                {
                    // act
                    order.CancelOrder();
                });
            //Assert.AreNotEqual(OrderStatus.Cancelled, order.Status);
        }
    }
}