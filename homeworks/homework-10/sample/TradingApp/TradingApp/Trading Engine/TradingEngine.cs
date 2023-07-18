namespace TradingApp
{
    // Тестируемость

    // TDD - Test Driven Development

    public interface ITradingEngine
    {
        event Action<string, OrderInfo> OrderMatched;

        string CreateOrder(OrderInfo orderInfo);
        bool CancelOrder(string orderId);
    }

    internal class TradingEngine : ITradingEngine
    {
        // синхронизация
        // сведение ордеров
        // - параллельное выполнение

        //предполагаю, что словарь будет содержать актуальные ордера
        private Dictionary<string, TradingOrder> _orders;

        public TradingEngine()
        {
            _orders = new Dictionary<string, TradingOrder>();
        }

        public string CreateOrder(OrderInfo orderInfo)
        {
            // TODO (Глеб Радывонюк): Определить идентификатор ордера

            // TODO (Глеб Радывонюк): Добавить в структуру таблицы ордеров

            // TODO (Павел Дунец): Организовать сведение ордеров

            return "orderId";
        }

        public bool CancelOrder(string orderId)
        {
            // TODO (Никита Качура): Найти и отменить ордер
            if(_orders.ContainsKey(orderId))
            {
                _orders[orderId].CancelOrder();

                return true;
            }

            return false;
        }

        public event Action<string, OrderInfo> OrderMatched;
    }
}
