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
        public Dictionary<DateTime, decimal> Data { get; }

        public Dictionary<string, Dictionary<DateTime, decimal>> MarketCap { get; } //Словарь с датой и значением
       

        Random random = new Random();
        

        SymbolInfo()
        {
            MarketCap = new Dictionary<string, decimal>()
            {
                { "MSFT", Data}, //Может сюда вставить словарь с ключом датой и ценой, нагенерить значений и выдовать по запросу?
                { "AAPL", },
                { "AMZN", 300},
                { "GOOG", 346},
                { "META", 689}
            };
            int num = 0;

            TimerCallback tm = new TimerCallback(Count);

            Timer timer = new Timer(tm, num, 0, 2000);
            
        }
        public void Count(object obj)
        {
            CurrentInfo(); //Возвращение новых данных каждые 2 сек, нужно подписаться на метод RetreiveInfo
        }
        public SymbolInfo RetreiveInfo(string symbolName, TimeSpan period, TimeSpan granularity)
        {
            var price = MarketCap[symbolName];
            return ;
        }
        
        
    }
}
