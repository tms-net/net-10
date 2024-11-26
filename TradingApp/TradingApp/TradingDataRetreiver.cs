namespace TradingApp
{
    // Получение - Евгений Липай
        // Получить данные по тикеру и частоте
        // InfoUpdated()
        // Получение данных для похожих символов

    // Получение
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
    }
}
