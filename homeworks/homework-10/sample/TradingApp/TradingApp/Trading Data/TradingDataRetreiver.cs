using System.Linq;
using System.Text.Json;
using TradingApp.Data;

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
        // Синхронизация
        // очередь обработки


        public string SymbolName { get; } //Символ компании на бирже
        public decimal MarketCap { get; } //Словарь с датой и значением
        public IDictionary<DateTime, decimal> Data { get; set; }

        public event Action<SymbolInfo> SymbolUpdated;

        public decimal? MarketPrice()
        {
            return Data?.LastOrDefault().Value; // Enumerable.LastOrDefault
        }

        public SymbolInfo(string symbolName)
        {
            // Сгененрировать объем акций
        }
    }

    internal class TradingDataRetreiver : ITradingDataRetreiver
    {
        static Lazy<TradingDataRetreiver> _instance = new Lazy<TradingDataRetreiver>(CreateInstance);

        public static TradingDataRetreiver Instance => _instance.Value;

        // Инициализатор типа
        static TradingDataRetreiver()
        {
            // _instance = new TradingDataRetreiver();
        }

        static TradingDataRetreiver CreateInstance()
        {
            return new TradingDataRetreiver();
        }

        const int MinimalGranularityMs = 5 * 60 * 1000;

        private readonly Random _random = new Random();
        private readonly Dictionary<DateTime, decimal> _dataMSFT = new Dictionary<DateTime, decimal>();
        private readonly Dictionary<DateTime, decimal> _dataAAPL = new Dictionary<DateTime, decimal>();

        private TradingDataRetreiver()
        {
            GenerateData();

            // Получить из файла

            // addr1:(object1)              addr2:(object2)         (object3) -> (object)(object2)(object3)

            // path: (23rekjfnberbokerbmeprelkge09ruger98guer0ue8rgye9rgy98eyg89eygekrjgbeg9e8rug23rkjb)
            //        ^      ^     

            // 1: полностью преобразовать
            //    обычное содержимое файла -> Substring(3,6) -> "файла"

            // 2: потоковое чтение/запись файла
            //    (от байта 3 прочитай 5 байт) -> "файла"

            // Файл vs Память
            // 1. Доступ к памяти быстрее
            // 2. Файл доступен всем приложениям -> persistent, память - temporary

            // потоковое
            FileStream fileStream = File.OpenRead("");
            //  опредленная блокировка операций с файлом

            // полностью преобразовать
            var content = File.ReadAllText("");
            File.WriteAllText("path", content);

            var msftData = JsonSerializer.Deserialize<TradingData>(content);

            // данные (бинарные, текстовые) -> объект
            // Сериализация

            // Дополнение текущими данными
            //  - Каждые 5 мин

            Timer timer = new Timer(UpdateData, null, MinimalGranularityMs, MinimalGranularityMs);
        }

        public SymbolInfo RetreiveInfo(string symbolName, TimeSpan period, TimeSpan granularity)
        {
            var now = DateTime.UtcNow;
            var start = now - period;

            // start -------------------------------------  now
            //       {            period                  }

            // 0    5m  10m   15m   20m     25m   30m   35m  - 5 min granularity

            // 0    5m  10m   15m    20m     25m   30m   35m  - 15 min granularity
            // {                  }{                   }{   } 
            
            // 15:00 <-       15:15 <-            15:30 <- - now 15:35 -> 15:45
            // [start ->       end]                        - average

            

            // Получение данных
            var symbolData = symbolName switch
            {
                "MSFT" => _dataMSFT,
                "AAPL" => _dataAAPL,
                _ => throw new NotSupportedException()
            };

            // Аггрегация данных

            // minGranularity = 5min
            // granularity = 15min
            // 0,1,2,3,4,5,6,7
            // 0,0,0,1,1,1,2,2,2

            // 15/5 = 3

            // index * minGranularity % granularity

            var groupping = ((long) granularity.TotalMilliseconds) / MinimalGranularityMs;

            // LINQ to Objects
            // LINQ = Language Intergated Query

            // from symbolData
            // where dataPoint.Key > start
            // select new { index, dataPoint }
            // group by dataIndex.index / groupping

            IDictionary<DateTime, decimal> data = symbolData
                .Where(dataPoint => dataPoint.Key > start) // filter
                // анонимный класс
                .Select((dataPoint, index) => new { index, dataPoint }) // map / проекция
                .ToLookup(dataIndex => dataIndex.index / groupping) // group
                .ToDictionary( // reduce материализация
                    group => group.Min(dataIndex => dataIndex.dataPoint.Key), // аггрегация для ключа
                    group => group.Average(dataIndex => dataIndex.dataPoint.Value) // аггрегация для значения
                ); 

            return new SymbolInfo(symbolName)
            {
                Data = data
            };
        }

        private void UpdateData(object? state)
        {
            // TODO: Вычислить рыночную цену исходя из сведенных ордеров и схоранить в исторические данные

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

            // сохранить в файл

            // объект -> данные (бинарные, текстовые) -> текстовые -> формат данных
            
            // бинарные -> в виде как объекты

            // .txt -> текст
            // .csv - comma separated values
            // .xml - extended markup language
            // .json - javascript object notation
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