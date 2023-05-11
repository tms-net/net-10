using System;

namespace TradingApp
{
        //   - Получить данные по тикеру и частоте
        //      - InfoUpdated()
        //      - Использовать делегат для уведомления компонент пользовательского интерфейса о наличии новых цен на акции.
        //      - Класс должен получать новые данные каждые X секунд и уведомлять компонент пользовательского интерфейса.
        //  - Получение данных для похожих символов

    public interface ITradingDataRetreiver
    {

        // От 01.01.2023 до now
        // TimeSpan (from -> to) - год, день, неделя
        // Enum -> год, день, неделя (Period)

        // гранулярность
        // Enum
        // Timespan
        SymbolInfo RetreiveInfo(string symbolName, TimeSpan period, TimeSpan granularity);
    }

    public class SymbolInfo
    {
        public string SymbolName { get; }
        public string MarketCap { get; }
        public IDictionary<DateTime, decimal> Data { get; }

        public event Action<SymbolInfo> SymbolUpdated;
    }

    internal class TradingDataRetreiver
    {
        TradingDataRetreiver() 
        {
            var company = new Dictionary<string, string>()
            {
                { "MSFT", ""},
                { "AAPL", ""},
                { "AMZN", ""},
                { "GOOG", ""},
                { "META", ""}
            };
            int num = 0;

            TimerCallback tm = new TimerCallback(Count);

            Timer timer = new Timer(tm, num, 0, 2000);
        }
        public static void Count(object obj)
        {
            int x = (int)obj;
            for (int i = 1; i < 9; i++, x++)
            {
                Console.WriteLine($"{x * i}");
            }
        }
    }

}
