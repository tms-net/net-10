namespace TradingApp
{
    public interface IAccountManager
    {
        void PlaceOrder(
            string symbol,
            int quantity,
            OrderSide orderType,
            decimal? price = null);

        decimal GetTotalCash();

        event Action<BalanceUpdatedArgs> BalanceUpdated;
    }

    public class AccountManager : IAccountManager
    {
        // 1000$
        // BUY MSFT
        // 300$ - 1 MSFT
        //  - 700$ + 1MSFT (Market Price) // - Broker Fee = 1000
        //  MSFT -> 310
        // - 700$ + 1MSFT (Market Price) = 1010
        // Difference = 1010 - 1000 = 10
        // SELL MSFT (310)
        // 1010$

        private readonly ITradingDataService _tradingDataRetreiver;
        private readonly ITradingEngine _tradingEngine;
        private readonly decimal _initialBalanceUSD;

        private Dictionary<string, decimal> _assets;

        public event Action<BalanceUpdatedArgs> BalanceUpdated;

        // IoC/DI

        // Dependency Injection
        // Inversion of Control

        public AccountManager(
            decimal balanceUSD,
            ITradingDataService tradingDataRetreiver,
            ITradingEngine tradingEngine)
        {
            // Currency Balance
            _initialBalanceUSD = balanceUSD;

            _tradingDataRetreiver = tradingDataRetreiver;
            _tradingEngine = tradingEngine;

            // Stocks
            _assets = new Dictionary<string, decimal>
            {
                ["USD"] = balanceUSD
            };

            // Full Balance
            //  - cash + stocks on current price
        }

        public void PlaceOrder(
            string symbol,
            int quantity,
            OrderSide orderType,
            decimal? price = null)
        {
            // Работа с акаунтом пользователя и торговым движком

            // 1. Валидация
            // 2. Создание сущностей ордеров
            // 3. Обновить баланс

            ValidateOrder(symbol, quantity,  orderType, price);

            // TODO (Даниил Ягниш): Создать ордер и сохранить для аккаунта

            var orderId = _tradingEngine.CreateOrder(new OrderInfo());
        }

        private /* ValidationResult */ /*bool*/ void ValidateOrder(string symbol, int quantity, OrderSide orderType, decimal? price)
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

            // TODO (Станислав Лютынский): Правильно написать логику валидации ордера на покупку по рыночной цене

            if (orderType == OrderSide.Buy && 
                price.HasValue && GetTotalCash() < price * quantity)
            {
                throw new InvalidOperationException("Invalid balance");
            }

            if (orderType == OrderSide.Sell && 
               (!_assets.TryGetValue(symbol, out var currentQuantity) || currentQuantity < quantity))
            {
                throw new InvalidOperationException("Invalid quantity");
            }
        }

        public decimal GetTotalCash()
        {
            return _assets.TryGetValue("USD", out var totalCash) ? totalCash : 0;
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