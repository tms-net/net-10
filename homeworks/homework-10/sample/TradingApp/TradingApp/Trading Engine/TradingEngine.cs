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


        // TODO Управление статусами

        // TODO Изменение параметров ордера

        public string CreateOrder(OrderInfo orderInfo)
        {
            // TODO: Определить идентификатор ордера

            // TODO: Добавить в структуру таблицы ордеров

            // TODO: Организовать сведение ордеров

            return "orderId";
        }

        public void CancelOrder(string orderId)
        {
            // TODO: Найти и отменить ордер
        }

        public event Action<string, OrderInfo> OrderMatched;
    }
}
