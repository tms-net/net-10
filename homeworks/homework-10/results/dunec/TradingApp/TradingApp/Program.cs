using TradingApp;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }

    internal static class TradingDataFromConsole
    {
        internal static string SetSymbolFromConsole()
        {
            string? result;

            while (true)
            {
                Console.WriteLine("Input Symbol name:");
                result = Console.ReadLine();
                if (result == null || result.Length != 0)
                {
                    Console.WriteLine($"Uncorrect Symbol name {result}");
                }
                else
                {
                    return result;
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

        public static TimeSpan PeriodForRetreiveInfo()
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

        public static TimeSpan GranularityForRetreiveInfo()
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


