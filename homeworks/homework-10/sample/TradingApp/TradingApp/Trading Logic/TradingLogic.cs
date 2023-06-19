using System.Diagnostics;
using TradingApp.Trading_Logic;

namespace TradingApp
{
    public class TradingLogic : ITradingLogic
    {
        private Dictionary<string, int> _stocks;
        private BalanceInfo _balance;
        private ITradingDataRetreiver _tradingDataRetreiver;
        private ITradingEngine _tradingEngine;
        public event Action<OrderInfo> OrderCompleted;

        public event Action<BalanceInfo> BalanceChanged;

        // IoC/DI

        // Dependency Injection
        // Inversion of Control

        public TradingLogic(
            decimal balance,
            // из файла, из сервиса            
            ITradingDataRetreiver tradingDataRetreiver,
            ITradingEngine tradingEngine)
        {
            // Currency Balance
            _balance = new BalanceInfo(balance);

            _tradingDataRetreiver = tradingDataRetreiver;
            _tradingEngine = tradingEngine;

            // Stocks
            _stocks = new Dictionary<string, int>();

            // Full Balance
            //  - _blance + _stocks omn current price

            //test data start
            //AddSymbol("w", 10);
            //test data end
        }

        public void PlaceOrder(
            string symbol,
            int quantity,
            OrderPriceType orderPriceType,
            OrderType orderType,
            Nullable<decimal> price = default
            //decimal? price = null // только для Price OrderType
            )
        {
            ValidateOrder(symbol, quantity, orderPriceType, orderType, price);

            IOrder order = orderType switch
            {
                OrderType.Buy => new BuyOrder(symbol, quantity, price ?? default),
                OrderType.Sell => new SellOrder(symbol, quantity, price ?? default),
                _ => throw new ArgumentException()
            };

            order.OrderApproved += OnOrderApproved;
        }

        private /* ValidationResult */ /*bool*/ void ValidateOrder(string symbol, int quantity, OrderPriceType orderPriceType, OrderType orderType, decimal? price)
        {

            // Validate order
            //  - Есть баланс для покупки
            //  - Валидный символ (?)
            //  - Соответствие значений параметров
            //      - Цена указана для Price Order Type

            SymbolInfo symbolInfo = _tradingDataRetreiver.RetreiveInfo(symbol, TimeSpan.MinValue, TimeSpan.MinValue);

            if (symbolInfo == null)
            {
                //return false;
                throw new InvalidOperationException("Invalid symbol");
            }

            if (quantity <= 0)
            {
                // throw new ArgumentException();

                throw new InvalidOperationException("Invalid quantity");
            }

            if (orderPriceType == OrderPriceType.Price && !price.HasValue)
            {
                throw new InvalidOperationException("Invalid price");
            }

            if (orderPriceType == OrderPriceType.Price && _balance.TotalBalance < price * quantity)
            {
                throw new InvalidOperationException("Invalid balance");
            }

            if (orderPriceType == OrderPriceType.Market &&
                _balance.TotalBalance < symbolInfo.MarketPrice() * quantity)
            {
                throw new InvalidOperationException("Invalid balance");
            }

            if (orderType == OrderType.Sell && 
               (!_stocks.TryGetValue(symbol, out var currentQuantity) || currentQuantity < quantity))
            {
                throw new InvalidOperationException("Invalid quantity");
            }
        }

        /// <summary>
        /// contains actions when status of order is known
        /// </summary>
        private void OnOrderApproved(OrderInfo orderInfo)
        {
            _balance.UpdateBalance(orderInfo.DealPrice, orderInfo.OrderType);

            OrderCompleted?.Invoke(orderInfo);
        }

        /// <summary>
        /// add one symbol with a specified quantity to the wallet
        /// </summary>
        private void AddSymbol(string symbol, int quantity)
        {
            _stocks.Add(symbol, quantity);
        }

        /// <summary>
        /// fill up wallet at the start
        /// </summary>
        public void FillWallet(Dictionary<string, int> newWallet)
        {
            if (newWallet != null)
            {
                _stocks = newWallet;
            }
        }
    }
}




/*example of making trade order from Program class
 * 
 * 
 * 
TradingLogic tradingLogic = new TradingLogic(100000, new TradingDataRetreiver());
tradingLogic.OrderCompleted += OnOrderCompleted;
tradingLogic.PlaceOrder("www", 1, 10, OrderPriceType.Market, OrderType.Buy);

static void OnOrderCompleted(OrderInfo orderInfo)
{
if(orderInfo.Status == DealStatus.Completed)
{
    Console.WriteLine("Test has been passed!");
}
}
*/