using System.Diagnostics;

namespace TradingApp
{
    public class TradingLogic : ITradingLogic
    {
        private Dictionary<string, int> _wallet;
        private BalanceInfo _balance;
        private BalanceInfo _balance;
        private ITradingDataRetreiver _tradingDataRetreiver;
        public event Action<OrderInfo> OrderCompleted;

        public event Action<BalanceInfo> BalanceChanged;

        public TradingLogic(decimal balance, ITradingDataRetreiver tradingDataRetreiver)
        {
            _balance = new BalanceInfo(balance);
            _balance = new BalanceInfo(balance);
            _tradingDataRetreiver = tradingDataRetreiver;
            _wallet = new Dictionary<string, int>();

            //test data start
<<<<<<< HEAD
            //AddSymbol("w", 10);
=======
            AddSymbol("w", 10);
>>>>>>> 619e580 (Added  check logic)
            //test data end
        }

        public void PlaceOrder(string symbol, int quantity, decimal price, OrderPriceType orderPriceType, OrderType orderType)
        {
            var orderCompleted = new OrderInfo();

            SymbolInfo symbolInfo = _tradingDataRetreiver.RetreiveInfo(symbol, TimeSpan.MinValue, TimeSpan.MinValue);

            if (orderType == OrderType.Buy && (_balance.TotalBalance >= price * quantity))
            {
                if(symbolInfo != null) //validation that the symbol is presented on the market
                {
                    BuyOrder order = new BuyOrder(this, symbol, quantity, price, orderPriceType);
<<<<<<< HEAD
                    order.OrderApproved += OnOrderApproved;
=======
>>>>>>> 619e580 (Added  check logic)

                    if (orderPriceType == OrderPriceType.Market)
                    {
                        order.MakeOrderMarket();
                    }
                    else
                    {
                        order.MakeOrderPrice();
                    }
<<<<<<< HEAD
                }
            }
            else if (_wallet.ContainsKey(symbol) && _wallet[symbol] >= quantity)
                {
                    SellOrder order = new SellOrder(this, symbol, quantity, price, orderPriceType);
                    order.OrderApproved += OnOrderApproved;

                if (orderPriceType == OrderPriceType.Market)
                    {
                        order.MakeOrderMarket();
                    }
                    else
                    {
                        order.MakeOrderPrice();
                    }
                }
            else
            {
                throw new ArgumentException();
            }
            
=======

                    order.OrderApproved += OnOrderApproved;
                }
            }
            else
            {
                if (_wallet.ContainsKey(symbol) && _wallet[symbol] >= quantity)
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
            }
>>>>>>> 619e580 (Added  check logic)
        }

        /// <summary>
        /// contains actions when status of order is known
        /// </summary>
        private void OnOrderApproved(bool isOrderApproved, OrderInfo orderInfo)
        {
            _balance.UpdateBalance(orderInfo.DealPrice, orderInfo.OrderType);

            OrderCompleted?.Invoke(orderInfo);
        }

        /// <summary>
        /// add one symbol with a specified quantity to the wallet
        /// </summary>
        private void AddSymbol(string symbol, int quantity)
        {
            _wallet.Add(symbol, quantity);
        }

        /// <summary>
        /// fill up wallet at the start
        /// </summary>
        public void FillWallet(Dictionary<string, int> newWallet)
        {
            if (newWallet != null)
            {
                _wallet = newWallet;
            }
        }
    }
}
