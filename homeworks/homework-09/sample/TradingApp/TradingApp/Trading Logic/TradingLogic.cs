namespace TradingApp
{
    public class TradingLogic : ITradingLogic
    {
        private Dictionary<string, int> _wallet;
        private decimal _balance;
        private ITradingDataRetreiver _tradingDataRetreiver;
        public event EventHandler<OrderInfo> OrderCompleted;

        public event Action<BalanceInfo> BalanceChanged;

        public TradingLogic(decimal balance, ITradingDataRetreiver tradingDataRetreiver)
        {
            _balance = balance;
            _tradingDataRetreiver = tradingDataRetreiver;
            _wallet = new Dictionary<string, int>();
        }

        public OrderInfo PlaceOrder(string symbol, int quantity, decimal price, OrderPriceType orderPriceType, OrderType orderType)
        {
            var orderCompleted = new OrderInfo();

            SymbolInfo symbolInfo = _tradingDataRetreiver.RetreiveInfo(symbol, TimeSpan.MinValue, TimeSpan.MinValue);

            if (orderType == OrderType.Buy)
            {
                BuyOrder order = new BuyOrder(this, symbol, quantity, price, orderPriceType);

                if (orderPriceType == OrderPriceType.Market)
                {
                    order.MakeOrderMarket();
                }
                else
                {
                    order.MakeOrderPrice();
                }

                order.OrderApproved += OnOrderApproved;
            }
            else
            {
                SellOrder order = new SellOrder(this, symbol, quantity, price, orderPriceType);

                if (orderPriceType == OrderPriceType.Market)
                {
                    order.MakeOrderMarket();
                }
                else
                {
                    order.MakeOrderPrice();
                }

                order.OrderApproved += OnOrderApproved;
            }

            return null;
        }


        /// <summary>
        /// contains actions when status of order is known
        /// </summary>
        private void OnOrderApproved(bool isOrderApproved)
        {
          
        }
        private void AddSymbol(string symbol, int quantity)
        {
            _wallet.Add(symbol, quantity);
        }

        //fill up wallet at the start
        public void FillWallet(Dictionary<string, int> newWallet)
        {
            if (newWallet != null)
            {
                _wallet = newWallet;
            }
        }

        public void Deposit(decimal amount)
        {
            _balance += amount;

            var balanceInfo = new BalanceInfo
            {
                TotalBalance = _balance,
                Difference = amount
            };
            // BalanceChanged?.Invoke(balanceInfo); // уведомление о пополнении баланса
        }
    }

    // Торговая логика - Никита Кочура
    // Купить/Продать
    // По рыночной цене - 100
    // Ордер
    // Цена достигла значения X 90
    // Отмена ордера при значении Y 80
    // Баланс    
}
