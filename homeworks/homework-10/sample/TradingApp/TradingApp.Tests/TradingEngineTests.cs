namespace TradingApp.Tests
{
    [TestClass]
    public class TradingEngineTests
    {
        [TestMethod]
        public void CreateOrderShouldGenerateUniqueIdentificators()
        {
            // 10 ордеров и у них должны быть
            //  - уникальные идентификаторы
            //  - последовательные идентификаторы

            // arrange
            var tradingEngine = new TradingEngine();
            var ids = new List<string>();

            // act
            for (int i = 0; i < 10; i++)
            {
                ids.Add(tradingEngine.CreateOrder(new OrderInfo
                {
                    OrderSide = OrderSide.Buy,
                    Price = 1,
                    Quantity = 1,
                    Symbol = "MSFT"
                }));
            }

            // assert
            CollectionAssert.AllItemsAreUnique(ids);
        }


        [TestMethod]
        public void CreateOrderShouldGenerateThreadSafeUniqueIdentificators()
        {
            // 10 ордеров и у них должны быть
            //  - уникальные идентификаторы
            //  - последовательные идентификаторы

            // arrange
            var tradingEngine = new TradingEngine();
            var createTasks = new List<Task<string>>();

            // act

            // TODO: Use PLINQ

            for (int i = 0; i < 10; i++)
            {
                createTasks.Add(Task.Run(() => tradingEngine.CreateOrder(new OrderInfo
                {
                    OrderSide = OrderSide.Buy,
                    Price = 1,
                    Quantity = 1,
                    Symbol = "MSFT"
                })));
            }
            Task.WaitAll(createTasks.ToArray());
            var ids = createTasks.Select(task => task.Result).ToArray();

            // assert
            CollectionAssert.AllItemsAreUnique(ids);
        }
    }
}
