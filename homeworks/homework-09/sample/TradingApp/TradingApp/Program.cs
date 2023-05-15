// See https://aka.ms/new-console-template for more information
using TradingApp;
{

    Console.WriteLine("Hello, World!");

}


    /*example of making trade order
     * 
     * 
     * 
    TradingLogic tradingLogic = new TradingLogic(100000, new TradingDataRetreiver());
    tradingLogic.OrderCompleted += OnOrderCompleted;
    tradingLogic.PlaceOrder("www", 1, 10, OrderPriceType.Market, OrderType.Buy);

}

static void OnOrderCompleted(OrderInfo orderInfo)
{
    if(orderInfo.Status == DealStatus.Completed)
    {
        Console.WriteLine("Test has been passed!");
    }
}
*/