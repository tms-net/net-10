using System.Collections.Generic;

namespace TradingApp
{
    // Тестируемость

    // TDD - Test Driven Development

    public interface ITradingEngine
    {
        event Action<string, OrderInfo> OrderMatched;

        string CreateOrder(OrderInfo orderInfo);
        void CancelOrder(string orderId);
    }

    internal class TradingEngine : ITradingEngine
    {
        // синхронизация
        // сведение ордеров
        // - параллельное выполнение
        long _ID = 0;
        public string CreateOrder(OrderInfo orderInfo)
        {
            // TODO (Глеб Радывонюк): Определить идентификатор ордера
            _ID++;
            // TODO (Глеб Радывонюк): Добавить в структуру таблицы ордеров
            Dictionary<long, OrderInfo> orderTable = new Dictionary<long, OrderInfo>();
            orderTable.Add(_ID,orderInfo);


            // TODO (Павел Дунец): Организовать сведение ордеров
            
            var tradingOrder = new TradingOrder(orderInfo);
            tradingOrder.MatchOrder(tradingOrder);
            return "orderId";
        }

        public void CancelOrder(string orderId)
        {
            // TODO (Никита Качура): Найти и отменить ордер
        }

        public event Action<string, OrderInfo> OrderMatched;
    }
}
