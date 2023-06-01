using System;
using System.Reflection.Metadata.Ecma335;

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

    public class SymbolInfo : ITradingDataRetreiver
    {

        public delegate void MethodContainer(); //Определяем делегат

        public event MethodContainer CurrentInfo; // Определяем событие на возвращение данных каждые 2 секунды после вызова метода RetreiveInfo
        public string SymbolName { get; } //Символ компании на бирже
        public Dictionary<DateTime, decimal> DataMSFT { get; }

        public Dictionary<DateTime, decimal> DataAAPL { get; }
        public Dictionary<string, Dictionary<DateTime, decimal>> MarketCap { get; } //Словарь с датой и значением

        DateTime dateNow = DateTime.Now;
        Random random = new Random();

        public SymbolInfo()
        {
            Dictionary<string, Dictionary<DateTime, decimal>> MarketCap = new Dictionary<string, Dictionary<DateTime, decimal>>();
            
            
            int count = 0;
            Dictionary<DateTime, decimal> DataMSFT = new Dictionary<DateTime, decimal>();
            Dictionary<DateTime, decimal> DataAAPL = new Dictionary<DateTime, decimal>();

            var startDate = new DateTime(2023,01,01);
            var interval = dateNow - startDate; //TimeSpan
            var interval1 = dateNow - interval; //DateTime
            for (interval = dateNow - startDate; interval1 <= dateNow; interval1.AddSeconds(2))
            {
                count++;
                if (count % 2 == 0)
                {
                    DataMSFT.Add(interval1, 308 - (decimal)random.NextDouble());
                    DataAAPL.Add(interval1, 308 - (decimal)random.NextDouble());
                }
                else
                {
                    DataMSFT.Add(interval1, 308 + (decimal)random.NextDouble());
                    DataAAPL.Add(interval1, 308 + (decimal)random.NextDouble());
                }

            }
          
            MarketCap.Add("MSFT", DataMSFT);
            MarketCap.Add("AAPL", DataAAPL);
            
            //{
            //    //["MSFT"] = new Dictionary<DateTime, decimal>  
            //    ////{ "AAPL", },
            //    ////{ "AMZN", 300},
            //    ////{ "GOOG", 346},
            //    ////{ "META", 689}
            //};
            int num = 0;

            TimerCallback tm = new TimerCallback(Count);

            Timer timer = new Timer(tm, num, 0, 2000);
            
        }
        public void Count(object obj)
        {
            CurrentInfo += GetCurrentInfo; //Возвращение новых данных каждые 2 сек
        }
        public SymbolInfo RetreiveInfo(string symbolName, TimeSpan period, TimeSpan granularity)
        {
            SymbolInfo info = new SymbolInfo();
           
            var price = MarketCap[symbolName][dateNow - period];
            return info;
        }
        public Dictionary<DateTime, decimal> RetreiveInfoOfSynbol(string symbolName, TimeSpan period, TimeSpan granularity)
        {
            SymbolInfo info = new SymbolInfo();

            var price = MarketCap[symbolName];
            return price;
        }
        public void GetCurrentInfo()
        {
            Console.WriteLine("dw"); // возвращать новые данные
        }
        
    }
    
}
