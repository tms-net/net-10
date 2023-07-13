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

        public string CreateOrder(OrderInfo orderInfo)
        {
            // TODO (Глеб Радывонюк): Определить идентификатор ордера

            // TODO (Глеб Радывонюк): Добавить в структуру таблицы ордеров

            // TODO (Павел Дунец): Организовать сведение ордеров

            return "orderId";
        }

        public void CancelOrder(string orderId)
        {
            // TODO (Никита Качура): Найти и отменить ордер
        }

        public event Action<string, OrderInfo> OrderMatched;
    }
}
