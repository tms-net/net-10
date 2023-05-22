using System;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Channels;
using TradingApp;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    static void Main(string[] args)
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Отображение
        //  - Экраны (Screen) ; Страница (Page) ; View
        //      - Home (Главный)
        //          - Текущие данные (символ, баланс, ...)
        //      - Опции отображения
        //      - Создание ордера

        Console.WriteLine("Hello, Trading Platform!");

        // Получить зависимости
        //  - ITradingDataRetreiver
        //  - ITradingLogic

        var random = new Random();
        var currentBalance = random.Next(1000, 100000);

        var tradingDataRetreiver = new TradingDataRetreiver();
        var tradingLogic = new TradingLogic(currentBalance, tradingDataRetreiver);        

        // Получить информацию для отображения данных
        var symbolName = TradingDataInConsole.GetSymbolFromConsole();
        var period = TradingDataInConsole.GetPeriodFromConsole();
        var granularity = TradingDataInConsole.GetGranularityFromConsole();

        TradingDataInConsole? console = null;
        // Отобразить данные

        var symbolData = tradingDataRetreiver.RetreiveInfo(symbolName, period, granularity);
        console = new TradingDataInConsole(symbolData, (decimal)currentBalance, tradingLogic);
        console.ShowMainInfo();


        // Опции для изменения отображения данных
        
        TradingDataInConsole.PauseInConsole();
        /*
        // Опции для создания ордера
        Console.WriteLine("Опции:");
        Console.WriteLine(" 1. Изменить гранулярность");
        Console.WriteLine(" 2. Изменить период");
        Console.WriteLine(" 3. Создать ордер");

        //while (true)
        //{
        //    var option = TradingDataInConsole.GetOptionFromConsole();

        //    // Обработка опции

        //    console.ShowMainInfo();
        //}//*/

        while (true)
        {
            bool exit = false;
            switch (TradingDataInConsole.ShowMenuOfOptions())
            {
                case 1:
                    {
                        console.UpdateSymbolInfo(tradingDataRetreiver.RetreiveInfo(symbolName, period, TradingDataInConsole.GetGranularityFromConsole()));
                    }
                    break;
                case 2:
                    {
                        console.UpdateSymbolInfo(tradingDataRetreiver.RetreiveInfo(symbolName, TradingDataInConsole.GetPeriodFromConsole(), granularity));
                    }
                    break;
                case 3:
                    {
                        symbolName = TradingDataInConsole.GetSymbolFromConsole();
                        var quantity = TradingDataInConsole.GetQuantityFromConsole();
                        var orderPriceType = TradingDataInConsole.GetOrderPriceTypeFromConsole();
                        var orderType = TradingDataInConsole.GetOrderTypeFromConsole();
                        try
                        {
                            if (orderPriceType == OrderPriceType.Price)
                            {
                                tradingLogic.PlaceOrder(symbolName, quantity, orderPriceType, orderType, TradingDataInConsole.GetPriceFromConsole());
                            }
                            else
                            {
                                tradingLogic.PlaceOrder(symbolName, quantity, orderPriceType, orderType);
                            }
                        }
                        catch (InvalidOperationException invalidOperationException)
                        {
                            TradingDataInConsole.ShowExceptionMessage(invalidOperationException);
                        }
                        catch (Exception exception)
                        {
                            TradingDataInConsole.ShowExceptionMessage(exception);
                        }

                        /*
                        switch (TradingDataInConsole.ShowCreatNewOrderMenu())
                        {
                            case 1:
                                {
                                    
                                    /*
                                    if (!TradingDataInConsole.IsOrderExist(console.buyOrder)) 
                                    {
                                        console.buyOrder = new BuyOrder(tradingLogic, TradingDataInConsole.GetSymbolFromConsole(), TradingDataInConsole.GetQuantityFromConsole(),
                                            TradingDataInConsole.GetDealPriceFromConsole(), TradingDataInConsole.GetOrderPriceTypeFromConsole());
                                    }    //
                                } 
                                break;
                            case 2: 
                                {
                                    /*
                                    if (!TradingDataInConsole.IsOrderExist(console.sellOrder))
                                    {
                                        console.sellOrder = new SellOrder(tradingLogic, TradingDataInConsole.GetSymbolFromConsole(), TradingDataInConsole.GetQuantityFromConsole(),
                                        TradingDataInConsole.GetDealPriceFromConsole(), TradingDataInConsole.GetOrderPriceTypeFromConsole());
                                    }//
                                }
                                break;
                        }//*/
                    }
                    break;
                case 0:
                    { exit = true; } break;
            }
            console.ShowMainInfo();
            TradingDataInConsole.PauseInConsole();
            if (exit || !TradingDataInConsole.AskAnotherAction()) { break; }
        }
    }

    internal class TradingDataInConsole
    {
        private SymbolInfo _symbolData;
        private decimal _currentBalance;
        //internal BuyOrder? buyOrder;
        //internal SellOrder? sellOrder;

        public TradingDataInConsole(SymbolInfo symbolData, decimal currentBalance, ITradingLogic tradingLogic)
        {
            _symbolData = symbolData;
            _currentBalance = currentBalance;

            tradingLogic.BalanceChanged += TradingLogic_BalanceChanged;
        }
        private void TradingLogic_BalanceChanged(BalanceInfo balanceInfo)
        {
            _currentBalance = balanceInfo.TotalBalance;
            ShowMainInfo();
        }

        public void UpdateSymbolInfo(SymbolInfo symbolData)
        {
            _symbolData = symbolData;
        }

        public static void PauseInConsole()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
        public static int ShowMenuOfOptions()
        {
            while (true)
            {                
                Console.Clear();
                Console.WriteLine("Options:");
                Console.WriteLine(" 1. Change granularity");
                Console.WriteLine(" 2. Change period");
                Console.WriteLine(" 3. Create order");
                Console.WriteLine(" 0. Exit");
                switch (Console.ReadLine())
                {
                    case "1": return 1;
                    case "2": return 2;
                    case "3": return 3;
                    case "0": return 0;
                    default: Console.WriteLine("Unavailable option code"); break;
                }
            }
        }
        internal static int ShowCreatNewOrderMenu()
        {
            while (true)
            {
                Console.WriteLine("Do you want to creat Buy order or Sell order?(b/s)");
                switch (Console.ReadLine())
                {
                    case "b": case "B": return 1;
                    case "s": case "S": return 2;
                    default: Console.WriteLine("Uncorrect input"); break;
                }
            }
        }
        internal static bool IsOrderExist(IOrder order)
        {
            if (order != null)
            {
                Console.WriteLine("Order already exist");
                return  true;
            }
            else
                return false;
        }
        internal static bool AskAnotherAction()
        {
            while (true)
            {
                Console.WriteLine("Do you want to make another action?(y/n)");
                switch (Console.ReadLine())
                {
                    case "y": case "Y": return true;
                    case "n": case "N": return false;
                    default: Console.WriteLine("Uncorrect input"); break;
                }
            }
        }
        /*
        internal static string GetOptionFromConsole()
        {
            string? result;

            while (true)
            {
                Console.WriteLine("Input Symbol name:");
                result = Console.ReadLine();
                if (result == null || result.Length != 0 || result.Length > 2)
                {
                    Console.WriteLine($"Incorrect Option name {result}");
                }
                else
                {
                    return result;
                }
            }
        }//*/

        internal static string GetSymbolFromConsole()
        {
            string? result;

            while (true)
            {
                Console.WriteLine("Input Symbol name:");
                result = Console.ReadLine();
                if (result == null || result.Length == 0)
                {
                    Console.WriteLine($"Incorrect Symbol name {result}");
                }
                else
                {
                    return result;
                }
            }
        }
        internal static TimeSpan GetPeriodFromConsole()
        {
            Console.WriteLine("For retrieving info need period");
            while (true)
            {
                Console.WriteLine("Input date FROM: ");
                if (!DateTime.TryParseExact(Console.ReadLine(), new string[] { "mm.dd.yyyy", "mm-dd-yyyy", "mm/dd/yyyy", "dd.mm.yyyy", "dd-mm-yyyy", "dd/mm/yyyy"}, 
                                            CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateTimeFrom))
                {
                    Console.WriteLine($"Uncorrect date");
                    continue;
                }
                

                //Console.WriteLine("Input date TO: ");
                //if (!DateTime.TryParse(Console.ReadLine(), out var dateTimeTo) || dateTimeTo < dateTimeFrom)
                //{
                //    Console.WriteLine($"Uncorrect date {dateTimeTo}");
                //}
                //else
                {
                    //return dateTimeTo - dateTimeFrom;
                    return DateTime.UtcNow - dateTimeFrom;
                }
            }
        }
        internal static TimeSpan GetGranularityFromConsole()
        {
            while (true)
            {
                Console.WriteLine("For retrieving info choose granularity (1 - 5min, 2 - 30min, 3 - 1hour, 4 - Day)");
                switch (Console.ReadLine())
                {
                    case "1": return TimeSpan.FromMinutes(5);
                    case "2": return TimeSpan.FromMinutes(30);
                    case "3": return TimeSpan.FromHours(1);
                    case "4": return TimeSpan.FromDays(1);
                    default: Console.WriteLine("Unavailable granularity code"); break;
                }
            }
        }


        internal static decimal GetPriceFromConsole()
        {
            decimal result;

            while (true)
            {
                Console.WriteLine("Input Price:");

                if (!decimal.TryParse(Console.ReadLine(), out result))
                {
                    Console.WriteLine($"Can't convert inputed text into decimal: {result}");
                }
                else
                {
                    return result;
                }
            }
        }
        internal static int GetQuantityFromConsole()
        {
            int result = 0;
            while (true)
            {
                Console.WriteLine("Input Quantity: ");
                if (!int.TryParse(Console.ReadLine(), out result))
                {
                    Console.WriteLine($"Can't convert inputed text into int: {result}");
                }
                else
                {
                    return result;
                }
            }
        }
        internal static OrderPriceType GetOrderPriceTypeFromConsole()
        {
            while (true)
            {
                Console.WriteLine($"Input Order price type (1 - {OrderPriceType.Market}, 2 - {OrderPriceType.Price}):");
                switch (Console.ReadLine())
                {
                    case "1": return OrderPriceType.Market;
                    case "2": return OrderPriceType.Price;
                    default: Console.WriteLine("Unavailable Order price type code"); break;
                }
            }
        }
        internal static OrderType GetOrderTypeFromConsole()
        {
            while (true)
            {
                Console.WriteLine($"Input Order type (1 - {OrderType.Buy}, 2 - {OrderType.Sell}):");
                switch (Console.ReadLine())
                {
                    case "1": return OrderType.Buy;
                    case "2": return OrderType.Sell;
                    default: Console.WriteLine("Unavailable Order type code"); break;
                }
            }
        }


        internal static DealStatus GetStatusFromConsole()
        {
            while (true)
            {
                Console.WriteLine($"Input Deal status (1 - {DealStatus.Pending}, 2 - {DealStatus.Completed}, 3 - {DealStatus.Cancelled}):");
                switch (Console.ReadLine())
                {
                    case "1": return DealStatus.Pending;
                    case "2": return DealStatus.Completed;
                    case "3": return DealStatus.Cancelled;
                    default: Console.WriteLine("Unavailable status code"); break;
                }
            }
        }

        internal void ShowMainInfo()
        {
            Console.Clear();
            Console.WriteLine($" Данные {_symbolData.SymbolName}:");
            //Console.WriteLine($" Текущая цена: {_symbolData.MarketPrice}"); 
            Console.WriteLine($" Текущая цена: {_symbolData.Data?.LastOrDefault().Value}");
            Console.WriteLine($" Капитализация: {_symbolData.MarketCap}");
            Console.WriteLine($" Баланс: {_currentBalance}");
        }

        internal static void ShowExceptionMessage(Exception exception)
        {
            Console.WriteLine($"Catch exception during work: {exception.Message}");
        }
    }
}

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