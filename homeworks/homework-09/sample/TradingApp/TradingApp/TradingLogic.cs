namespace TradingApp
{
    public class TradingLogic : ITradingLogic
    {
        private Dictionary<string, int> _wallet;
        private decimal _balance;
        private ITradingDataRetreiver _tradingDataRetreiver;
        public event EventHandler<OrderInfo> OrderCompleted;

        public TradingLogic(decimal balance, ITradingDataRetreiver tradingDataRetreiver)
        {
            _balance = balance;
            _tradingDataRetreiver = tradingDataRetreiver;
            _wallet = new Dictionary<string, int>();
        }

        public OrderInfo PlaceOrder(string symbol, int quantity, decimal price, OrderPriceType orderPriceType, OrderType orderType)
        {
            var orderCompleted = new OrderInfo();
            IOrder order;

            //SymbolInfo symbolInfo = _tradingDataRetreiver.RetreiveInfo(symbol, TimeSpan.MinValue, TimeSpan.MinValue);

            if (orderType == OrderType.Buy)
            {
                order = new BuyOrder(this);

                if (orderPriceType == OrderPriceType.Market)
                {
                    
                }
                else
                {

                }                
                    
            }
            else
            {
                order = new SellOrder(this);

                if (orderPriceType == OrderPriceType.Market)
                {

                }
                else
                {
                    //по сути нужно запрашивать разрешение на одобрение сделки. предлагаю сделать через генерацию рандом
                }
            }

           
        }

        private void AddSymbol(string symbol, int quantity)
        {
            _wallet.Add(symbol, quantity);
        }

        //fill up wallet in the start
        public void FillWallet(Dictionary<string, int> newWallet)
        {
            if (newWallet != null)
            {
                _wallet = newWallet;
            }
        }
    }

    // Торговая логика - Никита Кочура
    // Купить/Продать
    // По рыночной цене - 100
    // Ордер
    // Цена достигла значения X 90
    // Отмена ордера при значении Y 80
    // Баланс
    public interface ITradingLogic
    {
        // Купить по Рыночной цене

        // Продать по Рыночной цене

        // Купить когда цена X

        // Продать когда цена Y (есть на балансе)

        OrderInfo PlaceOrder(
            string symbol,
            int quantity,
            decimal price,
            OrderPriceType orderPriceType,
            OrderType orderType);

        event Action<BalanceInfo> BalanceChanged;
    }

    public class BalanceInfo
    {
        public decimal TotalBalance { get; set; }

        // Balance
        // Cash (1000)
        // Shares в валюте (изменяемое)
        public decimal Difference { get; set; }
    }

    public class OrderInfo
    {
        public string Symbol { get; set; }
        public decimal DealPrice { get; set; }
        public DealStatus Status { get; set; }
    }

    public enum DealStatus
    {
        Pending,
        Completed,
        Cancelled
    }

    public enum OrderPriceType
    {
        Market,
        Price
    }

    public enum OrderType
    {
        Buy,
        Sell
    }
}
