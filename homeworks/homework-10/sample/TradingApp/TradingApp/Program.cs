using TradingApp;

internal class Program
{
    private static void Main(string[] args)
    {
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
        var tradingDataRetreiver = new TradingDataRetreiver();
        var tradingLogic = new TradingLogic();
        var currentBalance = random.Next(1000, 100000);

        // Получить информацию для отображения данных
        var symbolName = TradingDataFromConsole.GetSymbolFromConsole();
        var period = TradingDataFromConsole.GetPeriodFromConsole();
        var granularity = TradingDataFromConsole.GetGranularityFromConsole();

        // Отобразить данные
        var symbolData = tradingDataRetreiver.RetreiveInfo(symbolName, period, granularity);

        var console = new TradingDataFromConsole(symbolData, currentBalance);

        // Опции для изменения отображения данных
        console.ShowMainInfo();        

        // Опции для создания ордера
        Console.WriteLine("Опции:");
        Console.WriteLine(" 1. Изменить гранулярность");
        Console.WriteLine(" 2. Изменить период");
        Console.WriteLine(" 3. Создать ордер");

        while (true)
        {
            var option = TradingDataFromConsole.GetOptionFromConsole();

            // Обработка опции

            console.ShowMainInfo();
        }
    }

    internal class TradingDataFromConsole
    {
        private SymbolInfo _symbolData;
        private int _currentBalance;

        public TradingDataFromConsole(SymbolInfo symbolData, int currentBalance)
        {
            _symbolData = symbolData;
            _currentBalance = currentBalance;
        }

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
        }

        internal static string GetSymbolFromConsole()
        {
            string? result;

            while (true)
            {
                Console.WriteLine("Input Symbol name:");
                result = Console.ReadLine();
                if (result == null || result.Length != 0)
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
            DateTime dateTimeFrom = DateTime.Now;
            DateTime dateTimeTo = DateTime.Now;
            Console.WriteLine("For retrieving info need period");
            while (true)
            {
                Console.WriteLine("Input date FROM: ");
                if (!DateTime.TryParse(Console.ReadLine(), out dateTimeFrom))
                {
                    Console.WriteLine($"Uncorrect date {dateTimeFrom}");
                }
                else { break; }
            }

            while (true)
            {
                Console.WriteLine("Input date TO: ");
                if (!DateTime.TryParse(Console.ReadLine(), out dateTimeTo) || dateTimeTo < dateTimeFrom)
                {
                    Console.WriteLine($"Uncorrect date {dateTimeTo}");
                }
                else
                {
                    return dateTimeTo - dateTimeFrom;
                }
            }
        }
        internal static TimeSpan GetGranularityFromConsole()
        {
            while (true)
            {
                Console.WriteLine("For retrieving info choose granularity (1 - Day, 2 - Week, 3 - Month, 4 - Year)");
                switch (Console.ReadLine())
                {
                    case "1": return DateTime.Now.AddDays(1) - DateTime.Now;
                    case "2": return DateTime.Now.AddDays(7) - DateTime.Now;
                    case "3": return DateTime.Now.AddMonths(1) - DateTime.Now;
                    case "4": return DateTime.Now.AddYears(1) - DateTime.Now;
                    default: Console.WriteLine("Unavailable granularity code"); break;
                }
            }
        }


        internal static decimal SetDealPriceFromConsole()
        {
            decimal result;

            while (true)
            {
                Console.WriteLine("Input Deal price:");

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

        internal static DealStatus SetStatusFromConsole()
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

        internal static int SetQuantityFromConsole()
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

        internal static OrderPriceType SetOrderPriceTypeFromConsole()
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

        internal static OrderType SetOrderTypeTypeFromConsole()
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

        internal void ShowMainInfo()
        {
            Console.Clear();
            Console.WriteLine($" Данные {_symbolData.SymbolName}:");
            Console.WriteLine($" Текущая цена: {_symbolData.Data.Last().Value}");
            Console.WriteLine($" Капитализация: {_symbolData.MarketCap}");
            Console.WriteLine($" Баланс: {_currentBalance}");
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