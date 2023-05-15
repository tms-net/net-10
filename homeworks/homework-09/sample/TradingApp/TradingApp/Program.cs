// See https://aka.ms/new-console-template for more information
using TradingApp;
{

    Console.WriteLine("Hello, World!");

    // delegate bool InfoUpdated(SymbolInfo symbolInfo);

    // UI - Павел Дунец
    // Основной символ (тикер) -> ввод пользователя
    // Текущее значение цены
    // Информация по символу

    // Сопутствующие символы
    // Значение
    // Изменение (↑ | ↓)

    // Возможность изменения частоты InfoUpdated += (Handler)
    // Функции


    TradingLogic tradingLogic = new TradingLogic(100, new TradingDataRetreiver());
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
