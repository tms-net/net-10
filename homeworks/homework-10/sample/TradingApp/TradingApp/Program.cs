using System;
using System.ComponentModel;
using System.Text;
using TradingApp;
using TradingApp.Trading_Logic;

internal class Program
{
    static void Main(string[] args)
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Имитация работы других трейдеров
        //  - создание ордеров
        //  - работа в разных потоках

        var tradingGenerator = new TradingGenerator();
        tradingGenerator.StartTradingDay();

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

        var tradingDataRetreiver = TradingDataRetreiver.Instance; //new TradingDataRetreiver();

        // Container.Register<ITradingDataRetreiver, TradingDataRetreiver>(LifeTime.Singleton)

        // TradingDataRetreiverFactory

        // Container.Register<ITradingDataRetreiver, TradingDataRetreiver>(() => new TradingDataRetreiver(), LifeTime.Singleton)

        // Container.Register<ITradingDataRetreiver, TradingDataRetreiver>(
        //  (ctx) => ctx.Resolve<TradingDataRetreiverFactory>().CreateRetriever(), LifeTime.Singleton)


        //var builder = new TradingDataRetreiverBuilder();

        // FluentInterface
        //var instance =
        //    builder
        //        .WithFile("C:file")
        //        .WithBuffer(400)
        //        .Build();

        //var sb = new StringBuilder();
        //sb.Append("")
        //  .AppendLine("");

        //sb.ToString();


        var da = new DealAccommodationService();
        var tradingEngine = new TradingEngine();
        var tradingLogic = new TradingLogic(currentBalance, tradingDataRetreiver, da, tradingEngine);

        // Регистрация зависимостей

        // FileTradingDataRetreiver который реализует ITradingDataRetreiver и существует в единственном экземпляре
        // TradingLogic который реализует ITradingLogic и существует в единственном экземпляре

        // Создание сущностей
        //  - Определение времени жизни
        //  - Внедрение зависимостей (Dependency Injection)

        // IoC/DI (Dependency Injection)

        // Container -> Control (создание, управлние сущностями), Injection

        // Interface == Service

        // Container.Resolve<ITradingLogic>()
        // -> dependencies
        //    - ITradingDataRetreiver
        //      - new TradingDataRetreiver()
        //    - IDealAccommodationService
        //      - new DealAccommodationService()

        // Container.Register<ITradingLogic, TradingLogic>()

        // Получить информацию для отображения данных
        var symbolName = TradingDataInConsole.GetSymbolFromConsole();
        var period = TradingDataInConsole.GetPeriodFromConsole();
        var granularity = TradingDataInConsole.GetGranularityFromConsole();

        // Отобразить данные
        var symbolData = tradingDataRetreiver.RetreiveInfo(symbolName, period, granularity);

        var console = new TradingDataInConsole(symbolData, (decimal)currentBalance, tradingLogic);

        // Опции для изменения отображения данных
        console.ShowMainInfo();

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
        //}

        while (true)
        {
            bool exit = false;
            switch (TradingDataInConsole.ShowMenuOfOptions())
            {
                case 1:
                    { }
                    break;
                case 2:
                    { }
                    break;
                case 3:
                    {

                    }
                    break;
                case 0:
                    { exit = true; }
                    break;
            }
            if (exit || TradingDataInConsole.AskAnotherAction())
            {
                break;
            }
        }
    }

    internal class TradingDataInConsole
    {
        private SymbolInfo _symbolData;
        private decimal _currentBalance;

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

        public static int ShowMenuOfOptions()
        {
            while (true)
            {
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

        public static bool AskAnotherAction()
        {
            while (true)
            {
                Console.WriteLine("Do you want to make anotehr action?(y/n)");
                switch (Console.ReadLine())
                {
                    case "y": case "Y": return true;
                    case "n": case "N": return false;
                    default: Console.WriteLine("Uncorrect input"); break;
                }
            }
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
                if (!DateTime.TryParse(Console.ReadLine(), out var dateTimeFrom))
                {
                    Console.WriteLine($"Uncorrect date {dateTimeFrom}");
                }
                else
                { 
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
                Console.WriteLine("For retrieving info choose granularity (1 - 5min, 2 - 30min, 3 - 1hiur, 4 - Day)");
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

    // Abstract Factory
    //interface IControlFactory
    //{
    //    IButton CreateButton();
    //    ICheckbox CreateCheckbox();
    //}

    public class TradingDataRetreiverBuilder
    {
        private string _path;

        // Последовательные вызовы

        // Классический

        public TradingDataRetreiverBuilder WithFile(string path)
        {
            _path = path;
            return this;
        }

        public TradingDataRetreiverBuilder Build() // Create()
        {
            return new TradingDataRetreiverBuilder();
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