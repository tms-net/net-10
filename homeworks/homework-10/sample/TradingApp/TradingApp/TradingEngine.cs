namespace TradingApp
{
    public interface ITradingEngine
    {
        void PlaceOrder(IOrder order);
    }

    internal class TradingEngine : ITradingEngine
    {
        // синхронизация
        // сведение ордеров
        // - параллельное выполнение

        public void PlaceOrder(IOrder order)
        {
            // TODO: Добавить в структуру таблицы ордеров

            // TODO: Организовать сведение ордеров
        }
    }
}
