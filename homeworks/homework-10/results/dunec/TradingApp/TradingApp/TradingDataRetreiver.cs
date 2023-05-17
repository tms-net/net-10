using System;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TradingApp
{
    //   - Получить данные по тикеру и частоте
    //      - InfoUpdated()
    //      - Использовать делегат для уведомления компонент пользовательского интерфейса о наличии новых цен на акции.
    //      - Класс должен получать новые данные каждые X секунд и уведомлять компонент пользовательского интерфейса.
    //   - Получение данных для похожих символов

    public interface ITradingDataRetreiver
    {
        SymbolInfo RetreiveInfo(string symbolName, TimeSpan period, TimeSpan granularity);
    }

    public class SymbolInfo
    {
        public string SymbolName { get; } //Символ компании на бирже
        public decimal MarketCap { get; } //Словарь с датой и значением
        public IDictionary<DateTime, decimal> Data { get; }

        public event Action<SymbolInfo> SymbolUpdated;

        public decimal? MarketPrice()
        {
            return Data?.LastOrDefault().Value; // Enumerable.LastOrDefault
        }

        public SymbolInfo()
        {
            // Сгененрировать объем акций
        }
    }

    internal class TradingDataRetreiver : ITradingDataRetreiver
    {
        const int MinimalGranularityMs = 5 * 60 * 1000;

        private readonly Random _random = new Random();
        private readonly Dictionary<DateTime, decimal> _dataMSFT = new Dictionary<DateTime, decimal>();
        private readonly Dictionary<DateTime, decimal> _dataAAPL = new Dictionary<DateTime, decimal>();

        public TradingDataRetreiver()
        {
            GenerateData();

            // Дополнение текущими данными
            //  - Каждые 5 мин
            
            Timer timer = new Timer(UpdateData, null, MinimalGranularityMs, MinimalGranularityMs);
        }

        public SymbolInfo RetreiveInfo(string symbolName, TimeSpan period, TimeSpan granularity)
        {
            // Получение данных

            // Аггрегация данных

            throw new NotImplementedException();
        }

        private void UpdateData(object? state)
        {
            var dateNow = DateTime.UtcNow;

            var rnd = _random.Next(1);
            var msftStartPrice = _dataMSFT.Last().Value; // IEnumerable.Last()
            var aaplStartPrice = _dataAAPL.Last().Value;

            if (rnd == 0)
            {
                _dataMSFT.Add(dateNow, msftStartPrice - msftStartPrice * (decimal)_random.NextDouble());
                _dataAAPL.Add(dateNow, aaplStartPrice - aaplStartPrice * (decimal)_random.NextDouble());
            }
            else
            {
                _dataMSFT.Add(dateNow, msftStartPrice + msftStartPrice * (decimal)_random.NextDouble());
                _dataAAPL.Add(dateNow, aaplStartPrice + aaplStartPrice * (decimal)_random.NextDouble());
            }
        }

        private void GenerateData()
        {
            // Генерация исторических данных
            //   - MSFT и AAPL
            //   - За день
            //   - Гранулярность -> Enum: 5 min, 30 min, 1h

            int count = 0;
            const int msftStartPrice = 308;
            const int aaplStartPrice = 200;

            var dateNow = DateTime.UtcNow;
            var startDate = dateNow.AddDays(-1);

            for (var date = startDate; date <= dateNow; date = date.AddMilliseconds(MinimalGranularityMs))
            {
                count++;
                if (count % 2 == 0)
                {
                    _dataMSFT.Add(date, msftStartPrice - msftStartPrice * (decimal)_random.NextDouble());
                    _dataAAPL.Add(date, aaplStartPrice - aaplStartPrice * (decimal)_random.NextDouble());
                }
                else
                {
                    _dataMSFT.Add(date, msftStartPrice + msftStartPrice * (decimal)_random.NextDouble());
                    _dataAAPL.Add(date, aaplStartPrice + aaplStartPrice * (decimal)_random.NextDouble());
                }
            }
        }
    }
}